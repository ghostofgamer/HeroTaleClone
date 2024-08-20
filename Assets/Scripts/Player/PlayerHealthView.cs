using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private TMP_Text _HealthValueText;

    private void OnEnable()
    {
        _playerHealth.HealthChanged += ChangeViewHealth;
    }

    private void OnDisable()
    {
        _playerHealth.HealthChanged -= ChangeViewHealth;
    }

    private void ChangeViewHealth(int maxHealth, int _currentHealth)
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