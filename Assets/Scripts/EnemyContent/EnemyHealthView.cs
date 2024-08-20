using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EnemyContent
{
    public class EnemyHealthView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private EnemyHealth _enemyHealth;
        [SerializeField] private TMP_Text _HealthValueText;

        private void OnEnable()
        {
            _enemyHealth.HealthChanged += ChangeViewHealth;
        }

        private void OnDisable()
        {
            _enemyHealth.HealthChanged -= ChangeViewHealth;
        }

        public void ChangeViewHealth(int maxHealth, int _currentHealth)
        {
            _slider.maxValue = maxHealth;
            _slider.value = _currentHealth;
            ShowHealthValue(maxHealth, _currentHealth);
        }

        private void ShowHealthValue(int maxHealth, int _currentHealth)
        {
            _HealthValueText.text = _currentHealth + " / " + maxHealth;
        }
    }
}
