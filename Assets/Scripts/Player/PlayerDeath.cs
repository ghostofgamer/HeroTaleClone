using UnityEngine;

namespace Player
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;

        private void OnEnable()
        {
            _playerHealth.Died += Die;
        }

        private void OnDisable()
        {
            _playerHealth.Died -= Die;
        }

        private void Die()
        {
        }
    }
}