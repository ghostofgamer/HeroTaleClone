using System.Collections.Generic;
using UnityEngine;
using WeaponContent;

namespace PlayerContent
{
    public class PlayerBag : MonoBehaviour
    {
        [SerializeField]private List<Weapon> _weapons = new List<Weapon>();

        public Weapon GetWeapon(int index)
        {
            if (index >= _weapons.Count)
                return null;

            return _weapons[index];
        }
    }
}