using AbstractionContent;
using UnityEngine;

namespace EnemyContent
{
    public class EnemyHealthView : AbstractionHealthView
    {
        [SerializeField] private EnemyHealth _enemyHealth;

        private void OnEnable()
        {
            _enemyHealth.HealthChanged += ChangeViewHealth;
        }

        private void OnDisable()
        {
            _enemyHealth.HealthChanged -= ChangeViewHealth;
        }
    }
}
