using System;
using UnityEngine;

namespace AbstractionContent
{
    public abstract class AbstractHealth : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ParticleSystem _damageEffect;

        private int _armor;

        public event Action Died;

        public event Action<int, int> HealthChanged;

        protected int Health { get; private set; }
        
        public int CurrentHealth { get; private set; }

        public void TakeDamage(int damage)
        {
            if (damage <= 0 || damage - _armor <= 0)
                return;

            CurrentHealth -= (damage - _armor);
            _audioSource.PlayOneShot(_audioSource.clip);
            _damageEffect.Play();
            HealthChanged?.Invoke(Health, CurrentHealth);

            if (CurrentHealth <= 0)
                Died?.Invoke();
        }

        public void HealHealth()
        {
            CurrentHealth = Health;
            HealthChange(Health, CurrentHealth);
        }

        protected void HealthChange(int maxHealth, int currentHealth)
        {
            HealthChanged?.Invoke(maxHealth, currentHealth);
        }

        protected virtual void Init(int maxHealth, int armor)
        {
            Health = maxHealth;
            CurrentHealth = Health;
            _armor = armor;
        }

        protected void ChangeHealthValue(int value)
        {
            if (value <= 0)
                return;
            
            Health += value;
        }
    }
}
