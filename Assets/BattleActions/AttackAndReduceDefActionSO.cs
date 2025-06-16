using UnityEngine;

[CreateAssetMenu(fileName = "AttackAndReduceDefActionSO", menuName = "Scriptable Objects/BattleActions/AttackAndReduceDefActionSO")]
public class AttackAndReduceDefActionSO: AbstractBattleActionSO
{
    public override void Act(BattleFieldMB battlefield, GameObject[] performers, GameObject[] targets)
    {
        GameObject attacker = performers[0];
        GameObject target = targets[0];
        //target.defence = target.defence / 2;
        bool wasDamage = BasicHit(attacker, target);

    }


}
