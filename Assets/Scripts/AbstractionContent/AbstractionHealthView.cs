using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AbstractionContent
{
    public class AbstractionHealthView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _healthValueText;
    
        public void ChangeViewHealth(int maxHealth, int currentHealth)
        {
            _slider.maxValue = maxHealth;
            _slider.value = currentHealth;
            ShowHealthValue(maxHealth, currentHealth);
        }

        private void ShowHealthValue(int maxHealth, int currentHealth)
        {
            _healthValueText.text = currentHealth + " / " + maxHealth;
        }
    }
}
