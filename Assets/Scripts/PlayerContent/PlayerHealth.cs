using System;
using SO;
using UnityEngine;

namespace PlayerContent
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private CharacterData _characterData;

        private int _health;
        
        public event Action Died;
        
        public event Action<int, int> HealthChanged;
        
        public int CurrentHealth { get; private set; }

        private void Start()
        {
            _health = _characterData.Health;
            CurrentHealth = _health;
            HealthChanged?.Invoke(_health, CurrentHealth);
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0 || damage - _characterData.Armor <= 0)
                return;

            CurrentHealth -= (damage - _characterData.Armor);
            HealthChanged?.Invoke(_health, CurrentHealth);

            if (CurrentHealth <= 0)
                Died?.Invoke();
        }

        public void HealHealth()
        {
            CurrentHealth = _characterData.Health;
            HealthChanged?.Invoke(_health, CurrentHealth);
        }
    }
}