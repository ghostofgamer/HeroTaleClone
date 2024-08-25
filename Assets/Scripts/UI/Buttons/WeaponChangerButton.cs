using PlayerContent;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class WeaponChangerButton : AbstractionButton
    {
        [SerializeField]private PlayerAttack _playerAttack;
        [SerializeField] private Image _icon;
        [SerializeField] private Sprite _scytheSprite;
        [SerializeField] private Sprite _bowSprite;

        public override void OnClick()
        {
            _playerAttack.Change();
            _icon.sprite = _playerAttack.IsScytheWeapon ? _bowSprite : _scytheSprite;
        }
    }
}
