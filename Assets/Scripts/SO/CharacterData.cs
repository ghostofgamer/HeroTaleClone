using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "NewCharacterData", menuName = "CharacterData", order = 51)]
    public class CharacterData : ScriptableObject
    {
        [SerializeField] private int _armor;
        [SerializeField] private int _health;
        [SerializeField] private int _attackPower;
        [SerializeField] private int _attackDelay;
    }
}
