using System;
using SO;
using UnityEngine;

namespace EnemyContent
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private EnemyData _enemyData;
        [SerializeField] private EnemyHealthView _enemyHealthView;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ParticleSystem _damageEffect;

        private int _health;
        public int CurrentHealth { get; private set; }

        public event Action Died;
        public event Action<int, int> HealthChanged;

        /*private void Start()
        {
            
        }*/
        private void OnEnable()
        {
            Init();
            _enemyHealthView.ChangeViewHealth(_health, CurrentHealth);
            // HealthChanged?.Invoke(_health, CurrentHealth);
        }

        public void Init()
        {
            _health = _enemyData.Health;
            CurrentHealth = _health;
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0 || damage - _enemyData.Armor <= 0)
                return;

            CurrentHealth -= (damage - _enemyData.Armor);
            _audioSource.PlayOneShot(_audioSource.clip);
            _damageEffect.Play();
            HealthChanged?.Invoke(_health, CurrentHealth);

            if (CurrentHealth <= 0)
                Died?.Invoke();
        }
    }
}