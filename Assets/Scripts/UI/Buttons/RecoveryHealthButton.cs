using PlayerContent;
using UnityEngine;

namespace UI.Buttons
{
    public class RecoveryHealthButton : AbstractionButton
    {
        [SerializeField] private PlayerHealth _playerHealth;
    
        public override void OnClick()
        {
            _playerHealth.HealHealth();
        }
    }
}
