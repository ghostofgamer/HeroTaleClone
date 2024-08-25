using System.Collections;
using EnemyContent;
using Interfaces;
using SO;
using UnityEngine;
using UnityEngine.UI;
using WeaponContent;

namespace PlayerContent
{
    [RequireComponent(typeof(MainPlayer))]
    public class PlayerAttack : MonoBehaviour, IAttackable
    {
        [SerializeField] private GameObject _stateIdle;
        [SerializeField] private GameObject _stateAttack;
        [SerializeField] private Image _imageStateAttack;
        [SerializeField] private Image _imageStateIdle;
        [SerializeField] private CharacterData _characterData;
        [SerializeField] private GameObject _gameObjectReload;
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerLevel _playerLevel;
        [SerializeField] private ParticleSystem _criticalEffect;
        [SerializeField] private PlayerBag _playerBag;

        private float _delay;
        private float _luck;
        private bool _isChange;
        private MainPlayer _player;
        private Weapon _weapon;
        private int _factorDamage = 2;
        private float _maxDelay = 1f;
        private float _minDelay = 0.3f;
        private float _factorDelay = 0.85f;
        private float _minLuck = 15f;
        private float _maxLuck = 35f;
        private float _factorLuck = 1;

        private bool IsAttack { get; set; }

        private bool IsAttackState { get; set; } = false;

        public bool IsScytheWeapon { get; private set; }

        private void OnEnable()
        {
            _playerLevel.LevelChanged += UpgradeValue;
        }

        private void OnDisable()
        {
            _playerLevel.LevelChanged -= UpgradeValue;
        }

        private void Start()
        {
            _weapon = _playerBag.GetWeapon(0);
            IsScytheWeapon = true;
            _animator.SetBool("ScytheWeapon", IsScytheWeapon);
            _player = GetComponent<MainPlayer>();
            _delay = _characterData.AttackDelay;
            _luck = _characterData.Luck;
        }

        public void ApplyAttack()
        {
            if (_player.Enemy == null)
                return;

            IsAttack = true;
            StartCoroutine(Attack());
        }

        public void StopAttack()
        {
            IsAttack = false;
            StopCoroutine(Attack());
        }

        public void Change()
        {
            if (!_isChange)
            {
                _isChange = true;
                IsScytheWeapon = !IsScytheWeapon;
            }
        }

        private IEnumerator Attack()
        {
            while (_player.Enemy.GetComponent<EnemyHealth>().CurrentHealth > 0 && IsAttack)
                yield return StartCoroutine(AttackCycle());
        }

        private IEnumerator AttackCycle()
        {
            yield return StartCoroutine(FillImage(_imageStateIdle, _delay, IsAttackState));
            IsAttackState = true;
            _animator.SetTrigger(IsScytheWeapon ? "ScytheAttack" : "BowAttack");
            _stateAttack.SetActive(true);
            _stateIdle.SetActive(false);
            yield return new WaitForSeconds(0.3f);
            int random = Random.Range(0, 100);

            if (random <= _luck)
                _criticalEffect.Play();

            _player.Enemy.GetComponent<EnemyHealth>().TakeDamage(random <= _luck ? _weapon.Damage * _factorDamage : _weapon.Damage);
            yield return StartCoroutine(FillImage(_imageStateAttack, _weapon.DelayAttack, IsAttackState));
            IsAttackState = false;
            _stateAttack.SetActive(false);
            _stateIdle.SetActive(true);

            if (_isChange)
                yield return StartCoroutine(ChangeWeapon());
        }

        private IEnumerator FillImage(Image image, float delay, bool stateAttack)
        {
            float elapsedTime = 0;
            float targetFillAmount = 1f;

            while (elapsedTime < delay)
            {
                if (_isChange && !stateAttack)
                    yield return StartCoroutine(ChangeWeapon());

                elapsedTime += Time.deltaTime;
                image.fillAmount = Mathf.Lerp(0, targetFillAmount, elapsedTime / delay);
                yield return null;
            }

            image.fillAmount = targetFillAmount;
        }

        private IEnumerator ChangeWeapon()
        {
            _gameObjectReload.SetActive(true);
            yield return new WaitForSeconds(2f);
            _isChange = false;
            _animator.SetBool("ScytheWeapon", IsScytheWeapon);
            _weapon = _playerBag.GetWeapon(IsScytheWeapon ? 0 : 1);
            _gameObjectReload.SetActive(false);
        }

        private void UpgradeValue()
        {
            _delay = Mathf.Clamp(_delay * _factorDelay, _minDelay, _maxDelay);
            _luck = Mathf.Clamp(_luck += _factorLuck, _minLuck, _maxLuck);
        }
    }
}