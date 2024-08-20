using Interfaces;
using SO;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(MainPlayer))]
    public class PlayerAttack : MonoBehaviour, IAttackable
    {
        [SerializeField] private GameObject _playerAttack;
        [SerializeField] private GameObject _playerIdle;
        [SerializeField] private CharacterData _characterData;
        [SerializeField] private Spawner _spawner;

        private float _delay;
        private float _damage;
        // private Enemy _enemy;

        private MainPlayer _player;
/*private void OnEnable()
{
    _spawner.EnemySpawned += Initialization;
}

private void OnDisable()
{
    _spawner.EnemySpawned -= Initialization;
}*/

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
        }
    }
}