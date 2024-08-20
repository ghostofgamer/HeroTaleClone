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
        public event Action<int,int> HealthChanged;

        private void Start()
        {
            _health = _characterData.Health;
            _currentHealth = _health;
            HealthChanged?.Invoke(_health, _currentHealth);
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0 || damage - _characterData.Armor <= 0)
                return;

            _currentHealth -= (damage - _characterData.Armor);
            HealthChanged?.Invoke(_health, _currentHealth);
            
            if (_currentHealth <= 0)
                Died?.Invoke();
        }
    }
}