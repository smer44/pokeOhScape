using UnityEngine;

[CreateAssetMenu(fileName = "BattleActionMenuContainerSO", menuName = "Scriptable Objects/BattleActionMenu/BattleActionMenuContainerSO")]
public class BattleActionMenuContainerSO : BattleActionMenuItemSO
{
    public BattleActionMenuItemSO[] items;

    public override BattleActionMenuItemSO DeepClone()
    {
        var clone = (BattleActionMenuContainerSO)this.MemberwiseClone();
        if (items != null)
        {
            clone.items = new BattleActionMenuItemSO[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    clone.items[i] = items[i].DeepClone();

                }

            }


        }
        return clone;

    }



}
