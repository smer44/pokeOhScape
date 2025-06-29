using UnityEngine;

[CreateAssetMenu(fileName = "BattleActionMenuItemSingleSO", menuName = "Scriptable Objects/BattleActionMenu/BattleActionMenuItemSingleSO")]
public class BattleActionMenuItemSingleSO : BattleActionMenuItemSO
{
    public AbstractBattleActionSO action;

    public override  BattleActionMenuItemSO DeepClone()
    {
        var clone = (BattleActionMenuItemSingleSO)this.MemberwiseClone();
        clone.action = action;
        return clone;
    }

}
