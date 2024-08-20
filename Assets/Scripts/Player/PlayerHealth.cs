using System;
using SO;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private CharacterData _characterData;

        private int _health;
        private int _currentHealth;

        public event Action Died;

        private void Start()
        {
            _health = _characterData.Health;
            _currentHealth = _health;
        }

        private void TakeDamage(int damage)
        {
            if (damage <= 0 || damage - _characterData.Armor <= 0)
                return;

            _currentHealth -= (damage - _characterData.Armor);

            if (_currentHealth <= 0)
                Died?.Invoke();
        }
    }
}