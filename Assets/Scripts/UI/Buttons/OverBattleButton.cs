using UnityEngine;

public class OverBattleButton : AbstractionButton
{
    [SerializeField] private OverBattle _overBattle;
    
    public override void OnClick()
    {
        _overBattle.EscapeFromBattle();
    }
}
