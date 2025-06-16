using UnityEngine;

[CreateAssetMenu(fileName = "AttackAndReduceDefActionSO", menuName = "Scriptable Objects/BattleActions/AttackAndReduceDefActionSO")]
public class AttackAndReduceDefActionSO: AbstractBattleActionSO
{
    public override void Act(BattleFieldMB battlefield, UnitSO[] performers, UnitSO[] targets)
    {
        UnitSO attacker = performers[0];
        UnitSO target = targets[0];
        target.defence = target.defence / 2;
        bool wasDamage = BasicHit(attacker, target);

    }


}
