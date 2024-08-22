using PlayerContent;
using UnityEngine;

namespace UI.Screens
{
    public class GameOverScreen : AbstractScreen
    {
        [SerializeField] private PlayerHealth _playerHealth;

        private void OnEnable()
        {
            _playerHealth.Died += Open;
        }

        private void OnDisable()
        {
            _playerHealth.Died -= Open;
        }
    }
}