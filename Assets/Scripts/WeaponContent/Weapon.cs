using SO;
using UnityEngine;

namespace WeaponContent
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponData _weaponData;

        public float DelayAttack { get; private set; }

        public int Damage { get; private set; }

        private void Start()
        {
            DelayAttack = _weaponData.Delay;
            Damage = _weaponData.Damage;
        }
    }
}