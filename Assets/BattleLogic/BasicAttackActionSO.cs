using UnityEngine;

[CreateAssetMenu(fileName = "BasicAttackActionSO", menuName = "Scriptable Objects/BasicAttackActionSO")]
public class BasicAttackActionSO : BattleActionSO
{
    public override void Act(BattleFieldSO battlefield, UnitSO[] performers, UnitSO[] targets)
    {
        UnitSO attacker = performers[0];
        UnitSO target = targets[0];
        bool wasDamage = BasicHit(attacker, target);

    }

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
