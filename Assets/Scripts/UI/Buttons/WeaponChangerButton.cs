using PlayerContent;
using UnityEngine;

namespace UI.Buttons
{
    public class WeaponChangerButton : AbstractionButton
    {
        [SerializeField] private WeaponChanger _weaponChanger;
        [SerializeField]private PlayerAttack _playerAttack;
        
        public override void OnClick()
        {
            _playerAttack.Change();
            // _weaponChanger.ChangeWeapon();
        }
    }
}
