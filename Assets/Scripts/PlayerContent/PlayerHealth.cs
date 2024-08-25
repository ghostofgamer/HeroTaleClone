using System;
using SO;
using UnityEngine;

namespace PlayerContent
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private CharacterData _characterData;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ParticleSystem _damageEffect;
        
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
            _audioSource.PlayOneShot(_audioSource.clip);
            _damageEffect.Play();
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