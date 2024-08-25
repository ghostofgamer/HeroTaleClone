using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "NewWeaponData", menuName = "WeaponData", order = 51)]
    public class WeaponData : ScriptableObject
    {
        [SerializeField]private float _delay;
        [SerializeField]private int _damage;

        public float Delay => _delay;
        
        public int Damage => _damage;
    }
}
