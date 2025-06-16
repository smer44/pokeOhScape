using UnityEngine;

[CreateAssetMenu(fileName = "BasicAttackAction", menuName = "Scriptable Objects/BattleActions/BasicAttackAction")]
public class BasicAttackAction: AbstractBattleActionSO
{
    public override void Act(BattleFieldMB battlefield, UnitSO[] performers, UnitSO[] targets)
    {
        UnitSO attacker = performers[0];
        UnitSO target = targets[0];
        bool wasDamage = BasicHit(attacker, target);

    }


}
