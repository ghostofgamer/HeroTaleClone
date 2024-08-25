using System;
using TMPro;
using UnityEngine;

namespace PlayerContent
{
    public class PlayerLevel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private ParticleSystem _levelUpEffect;

        private int _level = 1;
        private int _currentExperience = 0;
        private int _maxExperience = 6;
        private float _factor = 1.5f;

        public event Action<int, int> ExperienceChanged;
        public event Action LevelChanged;

        public int Level => _level;

        private void Start()
        {
            ExperienceChanged?.Invoke(_currentExperience, _maxExperience);
        }

        public void AddExperience(int experience)
        {
            _currentExperience += experience;
            ExperienceChanged?.Invoke(_currentExperience, _maxExperience);

            if (_currentExperience >= _maxExperience)
                TakeNewLevel();
        }

        private void TakeNewLevel()
        {
            _level++;
            LevelChanged?.Invoke();
            _levelUpEffect.Play();
            _levelText.text = $"{_level.ToString()} Level";
            _currentExperience -= _maxExperience;
            _maxExperience = Mathf.RoundToInt(_maxExperience * _factor);
            ExperienceChanged?.Invoke(_currentExperience, _maxExperience);
        }
    }
}