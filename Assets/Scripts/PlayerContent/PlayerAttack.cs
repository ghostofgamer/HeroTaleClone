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
        [SerializeField] private GameObject _playerAttack;
        [SerializeField] private GameObject _playerIdle;
        [SerializeField] private GameObject _stateIdle;
        [SerializeField] private GameObject _stateAttack;
        [SerializeField] private Image _imageStateAttack;
        [SerializeField] private Image _imageStateIdle;
        [SerializeField] private WeaponChanger _weaponChanger;

        [SerializeField] private CharacterData _characterData;
        [SerializeField] private Spawner _spawner;

        [SerializeField] private GameObject _gameObjectReload;


        [SerializeField] private Animator _animator;
        [SerializeField] private AudioSource _audioSource;

        private float _delay;
        private int _damage;

        private bool _isChange;

        public bool IsAttack { get; private set; }

        public bool IsReload { get; private set; }

        public bool IsScytheWeapon { get; private set; }

        private MainPlayer _player;

        private void Start()
        {
            IsScytheWeapon = true;
            _animator.SetBool("ScytheWeapon", IsScytheWeapon);
            _player = GetComponent<MainPlayer>();
            _delay = _characterData.AttackDelay;
            _damage = _characterData.Damage;
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
            /*_playerAttack = weaponAttack;
            _playerIdle = weaponIdle;*/
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
                        // _weaponChanger.ChangeWeapon();

                        _animator.SetBool("ScytheWeapon", IsScytheWeapon);
                        _gameObjectReload.SetActive(false);
                    }

                    elapsedTime += Time.deltaTime;
                    _imageStateIdle.fillAmount = Mathf.Lerp(0, targetFillAmount, elapsedTime / _delay);
                    yield return null;
                }

                _imageStateIdle.fillAmount = targetFillAmount;

                if (IsScytheWeapon)
                {
                    _animator.SetTrigger("ScytheAttack");
                }
                else
                {
                    _animator.SetTrigger("BowAttack");
                }

                // _playerAttack.SetActive(true);
                _stateAttack.SetActive(true);
                // _playerIdle.SetActive(false);
                _stateIdle.SetActive(false);
                yield return new WaitForSeconds(0.3f);
                _player.Enemy.GetComponent<EnemyHealth>().TakeDamage(_damage);

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

                // _playerAttack.SetActive(false);
                _stateAttack.SetActive(false);
                // _playerIdle.SetActive(true);
                _stateIdle.SetActive(true);

                if (_isChange)
                {
                    _gameObjectReload.SetActive(true);
                    yield return new WaitForSeconds(2f);

                    _isChange = false;
                    // _weaponChanger.ChangeWeapon();
                    _animator.SetBool("ScytheWeapon", IsScytheWeapon);
                    Debug.Log(IsScytheWeapon);
                    _gameObjectReload.SetActive(false);
                }
            }
        }

        public void StopAttack()
        {
            IsAttack = false;
            StopCoroutine(Attack());
            /*_playerAttack.SetActive(false);
            _stateAttack.SetActive(false);
            _playerIdle.SetActive(true);
            _stateIdle.SetActive(true);*/
        }

        public void Change()
        {
            if (!_isChange)
            {
                _isChange = true;
                IsScytheWeapon = !IsScytheWeapon;
            }
        }
    }
}