using UnityEngine;

[CreateAssetMenu(fileName = "BasicAttackAction", menuName = "Scriptable Objects/BattleActions/BasicAttackAction")]
public class BasicAttackAction: AbstractBattleActionSO
{
    public override void Act(BattleFieldMB battlefield, GameObject[] performers, GameObject[] targets)
    {
        GameObject attacker = performers[0];
        GameObject target = targets[0];
        bool wasDamage = BasicHit(attacker, target);

    }


}
