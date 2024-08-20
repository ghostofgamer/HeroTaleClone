using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "NewEnemyData", menuName = "EnemyData", order = 51)]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private int _armor;
        [SerializeField] private int _health;
        [SerializeField] private int _attackPower;
        [SerializeField] private int _attackDelay;
        [SerializeField] private int _spawnChance;
    }
}
