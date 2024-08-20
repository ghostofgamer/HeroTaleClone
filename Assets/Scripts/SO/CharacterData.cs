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

        public int Armor => _armor;
        
        public int Health => _health;
        
        public int Damage => _damage;
        
        public float AttackDelay => _attackDelay;
    }
}