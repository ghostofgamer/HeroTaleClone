using AbstractionContent;
using SO;
using UnityEngine;

namespace PlayerContent
{
    public class PlayerHealth : AbstractHealth
    {
        [SerializeField] private CharacterData _characterData;
        [SerializeField] private PlayerLevel _playerLevel;

        private int _factor = 5;

        private void OnEnable()
        {
            _playerLevel.LevelChanged += UpgradeHealth;
        }

        private void OnDisable()
        {
            _playerLevel.LevelChanged -= UpgradeHealth;
        }

        private void Start()
        {
            Init(_characterData.Health, _characterData.Armor);
        }

        protected override void Init(int maxHealth, int armor)
        {
            base.Init(maxHealth, armor);
            HealthChange(Health, CurrentHealth);
        }

        private void UpgradeHealth()
        {
            ChangeHealthValue(_factor * _playerLevel.Level);
            HealthChange(Health, CurrentHealth);
        }
    }
}