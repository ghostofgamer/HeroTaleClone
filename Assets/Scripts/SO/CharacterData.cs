using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "NewCharacterData", menuName = "CharacterData", order = 51)]
    public class CharacterData : ScriptableObject
    {
        [SerializeField] private int _armor;
        [SerializeField] private int _health;
        [SerializeField] private int _damage;
        [SerializeField] private float _attackDelay;
        [SerializeField] private float _luck;
        [SerializeField] private int _level;

        public int Armor => _armor;
        
        public int Health => _health;
        
        public int Damage => _damage;
        
        public float AttackDelay => _attackDelay;
        
        public float Luck => _luck;
        
        public int Level => _level;
    }
}