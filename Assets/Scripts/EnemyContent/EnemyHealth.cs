using AbstractionContent;
using SO;
using UnityEngine;

namespace EnemyContent
{
    public class EnemyHealth : AbstractHealth
    {
        [SerializeField] private EnemyData _enemyData;
        [SerializeField] private EnemyHealthView _enemyHealthView;

        private void OnEnable()
        {
            Init(_enemyData.Health,_enemyData.Armor);
            _enemyHealthView.ChangeViewHealth(Health, CurrentHealth);
        }
    }
}