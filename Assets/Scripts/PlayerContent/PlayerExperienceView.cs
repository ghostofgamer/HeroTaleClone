using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerContent
{
    public class PlayerExperienceView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _valueText;
        [SerializeField] private PlayerLevel _playerLevel;

        private void OnEnable()
        {
            _playerLevel.ExperienceChanged += ShowExperience;
        }

        private void OnDisable()
        {
            _playerLevel.ExperienceChanged -= ShowExperience;
        }

        private void ShowExperience(int currentExperience, int maxExperience)
        {
            _slider.value = currentExperience;
            _slider.maxValue = maxExperience;
            _valueText.text = $"{currentExperience} / {maxExperience}";
        }
    }
}