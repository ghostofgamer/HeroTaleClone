using UnityEngine;

namespace EnemyContent
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _enemyHealth;

        private void OnEnable()
        {
            _enemyHealth.Died += Die;
        }

        private void OnDisable()
        {
            _enemyHealth.Died -= Die;
        }

        private void Die()
        {
            Debug.Log("PlayerDeath");
        }
    }
}
