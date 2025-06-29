using UnityEngine;


public abstract class BattleActionMenuItemSO : ScriptableObject
{
    public string name;

    public string? ToString()
    {
        return name;

    }

    public abstract BattleActionMenuItemSO DeepClone();
    
}
