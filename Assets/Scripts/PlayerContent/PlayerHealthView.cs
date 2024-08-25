using AbstractionContent;
using UnityEngine;

namespace PlayerContent
{
    public class PlayerHealthView : AbstractionHealthView
    {
        [SerializeField] private PlayerHealth _playerHealth;

        private void OnEnable()
        {
            _playerHealth.HealthChanged += ChangeViewHealth;
        }

        private void OnDisable()
        {
            _playerHealth.HealthChanged -= ChangeViewHealth;
        }
    }
}