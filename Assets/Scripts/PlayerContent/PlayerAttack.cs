using System.Collections;
using EnemyContent;
using Interfaces;
using SO;
using UnityEngine;
using UnityEngine.UI;

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

        private float _delay;
        private float _luck;
        private int _damage;
        private bool _isChange;
        private MainPlayer _player;

        public bool IsAttack { get; private set; }

        public bool IsReload { get; private set; }

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
            IsScytheWeapon = true;
            _animator.SetBool("ScytheWeapon", IsScytheWeapon);
            _player = GetComponent<MainPlayer>();
            _delay = _characterData.AttackDelay;
            _damage = _characterData.Damage;
            _luck = _characterData.Luck;
        }

        public void ApplyAttack()
        {
            if (_player.Enemy == null)
                return;

            IsAttack = true;
            StartCoroutine(Attack());
        }

        public void InitWeapon(GameObject weaponAttack, GameObject weaponIdle)
        {
            IsScytheWeapon = !IsScytheWeapon;
            Debug.Log(IsScytheWeapon);
        }

        private IEnumerator Attack()
        {
            while (_player.Enemy.GetComponent<EnemyHealth>().CurrentHealth > 0 && IsAttack)
            {
                float elapsedTime = 0;
                _imageStateIdle.fillAmount = 0;
                float targetFillAmount = 1f;
                while (elapsedTime < _delay)
                {
                    if (_isChange)
                    {
                        _gameObjectReload.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        _isChange = false;
                        _animator.SetBool("ScytheWeapon", IsScytheWeapon);
                        _gameObjectReload.SetActive(false);
                    }

                    elapsedTime += Time.deltaTime;
                    _imageStateIdle.fillAmount = Mathf.Lerp(0, targetFillAmount, elapsedTime / _delay);
                    yield return null;
                }

                _imageStateIdle.fillAmount = targetFillAmount;
                _animator.SetTrigger(IsScytheWeapon ? "ScytheAttack" : "BowAttack");
                _stateAttack.SetActive(true);
                _stateIdle.SetActive(false);
                yield return new WaitForSeconds(0.3f);

                int random = Random.Range(0, 100);

                if (random <= _luck)
                    _criticalEffect.Play();

                _player.Enemy.GetComponent<EnemyHealth>().TakeDamage(random <= _luck ? _damage * 2 : _damage);
                elapsedTime = 0;
                _imageStateAttack.fillAmount = 0;
                targetFillAmount = 1f;

                while (elapsedTime < _delay)
                {
                    elapsedTime += Time.deltaTime;
                    _imageStateAttack.fillAmount = Mathf.Lerp(0, targetFillAmount, elapsedTime / _delay);
                    yield return null;
                }

                _imageStateAttack.fillAmount = targetFillAmount;
                _stateAttack.SetActive(false);
                _stateIdle.SetActive(true);

                if (_isChange)
                {
                    _gameObjectReload.SetActive(true);
                    yield return new WaitForSeconds(2f);
                    _isChange = false;
                    _animator.SetBool("ScytheWeapon", IsScytheWeapon);
                    _gameObjectReload.SetActive(false);
                }
            }
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

        private void UpgradeValue()
        {
            _delay = Mathf.Clamp(_delay * 0.5f, 0.3f, 1f);
            _luck = Mathf.Clamp(_luck += 1, 15, 35);
        }
    }
}