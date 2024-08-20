using SO;
using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private GameObject _playerAttack;
        [SerializeField] private GameObject _playerIdle;
        [SerializeField] private CharacterData _characterData;
        
        private float _delay;
        private float _damage;

        private void Start()
        {
            _delay = _characterData.AttackDelay;
            _damage = _characterData.Damage;
        }
    }
}
