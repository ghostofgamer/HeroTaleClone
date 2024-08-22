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
        
        
        [SerializeField] private CharacterData _characterData;
        [SerializeField] private Spawner _spawner;

        private float _delay;
        private int _damage;
        private bool _isAttack;

        private MainPlayer _player;

        private void Start()
        {
            _player = GetComponent<MainPlayer>();
            _delay = _characterData.AttackDelay;
            _damage = _characterData.Damage;
        }

        public void ApplyAttack()
        {
            if (_player.Enemy == null)
                return;
            
            _isAttack = true;
            StartCoroutine(Attack());
        }

        private IEnumerator Attack()
        {
            while (_player.Enemy.GetComponent<EnemyHealth>().CurrentHealth > 0&&_isAttack)
            {
                Debug.Log("ываываываываываыаыаыа");
                
                float elapsedTime = 0;
                _imageStateIdle.fillAmount = 0;
                float targetFillAmount = 1f;
                while (elapsedTime < _delay)
                {
                    elapsedTime += Time.deltaTime;
                    _imageStateIdle.fillAmount = Mathf.Lerp(0, targetFillAmount, elapsedTime / _delay);
                    yield return null;
                }
                
                _imageStateIdle.fillAmount = targetFillAmount;


                _playerAttack.SetActive(true);
                _stateAttack.SetActive(true);
                _playerIdle.SetActive(false);
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

                // yield return new WaitForSeconds(_delay);
                
                
                _playerAttack.SetActive(false);
                _stateAttack.SetActive(false);
                _playerIdle.SetActive(true);
                _stateIdle.SetActive(true);
            }
        }

        public void StopAttack()
        {
            Debug.Log("StopAttack");
            _isAttack = false;
            StopCoroutine(Attack());
            _playerAttack.SetActive(false);
            _stateAttack.SetActive(false);
            _playerIdle.SetActive(true);
            _stateIdle.SetActive(true);
        }
    }
}