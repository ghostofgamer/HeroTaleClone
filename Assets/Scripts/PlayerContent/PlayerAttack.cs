using System.Collections;
using EnemyContent;
using Interfaces;
using SO;
using UnityEngine;

namespace PlayerContent
{
    [RequireComponent(typeof(MainPlayer))]
    public class PlayerAttack : MonoBehaviour, IAttackable
    {
        [SerializeField] private GameObject _playerAttack;
        [SerializeField] private GameObject _playerIdle;
        [SerializeField] private CharacterData _characterData;
        [SerializeField] private Spawner _spawner;

        private float _delay;
        private int _damage;

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

            StartCoroutine(Attack());
        }

        private IEnumerator Attack()
        {
            while (_player.Enemy.GetComponent<EnemyHealth>().CurrentHealth > 0)
            {
                yield return new WaitForSeconds(_delay);
                _playerAttack.SetActive(true);
                _playerIdle.SetActive(false);
                _player.Enemy.GetComponent<EnemyHealth>().TakeDamage(_damage);
                yield return new WaitForSeconds(_delay);
                _playerAttack.SetActive(false);
                _playerIdle.SetActive(true);
            }
        }
    }
}