using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "NewEnemyData", menuName = "EnemyData", order = 51)]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private int _armor;
        [SerializeField] private int _health;
        [SerializeField] private int _damage;
        [SerializeField] private float _attackDelay;
        [SerializeField] private float _spawnChance;
        [SerializeField] private int _experience;

        public int Armor => _armor;

        public int Health => _health;

        public int Damage => _damage;

        public float AttackDelay => _attackDelay;

        public float SpawnChance => _spawnChance;
        
        public int Experience => _experience;
    }
}