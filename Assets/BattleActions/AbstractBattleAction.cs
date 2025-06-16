using UnityEngine;

//[CreateAssetMenu(fileName = "AbstractBattleActionSO", menuName = "Scriptable Objects/BattleActions/BattleActionMenuItemSingleSO")]
public abstract class AbstractBattleActionSO : ScriptableObject
{
    public abstract void Act(BattleFieldMB field, UnitSO[] performers, UnitSO[] targets);


    public bool BasicHit(UnitSO attacker, UnitSO target)
    {

        int damage = attacker.attack - target.defence;
        bool wasDamage = damage > 0;
        if (wasDamage)
        {
            target.TakeDamage(damage);
        }
        return wasDamage;
    }
    
}
