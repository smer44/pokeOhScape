using UnityEngine;

//[CreateAssetMenu(fileName = "AbstractBattleActionSO", menuName = "Scriptable Objects/BattleActions/BattleActionMenuItemSingleSO")]
public abstract class AbstractBattleActionSO : ScriptableObject
{
    public abstract void Act(BattleFieldMB field, GameObject[] performers, GameObject[] targets);

    public int maxPerformers = 1;
    public int maxTargets = 1;



    //Basic actions implementation:

    public bool BasicHit(GameObject attackeri, GameObject targeit)
    {
        UnitMB attacker = attackeri.GetComponent<UnitMB>();
        UnitMB target = targeit.GetComponent<UnitMB>();
        return BasicHit(attacker.data, target.data);
    }


    public bool BasicHit(UnitSO attacker, UnitSO target)
    {
        int damage = attacker.attack - target.defence;
        bool wasDamage = damage > 0;
        if (wasDamage)
        {
            TakeDamage(target, damage);
        }
        return wasDamage;       


    }





    public void HalfDef(GameObject unit)
    {


    }



    public void TakeDamage(ObjectWithHitPointsSO obj, int damageAmount)
    {
        obj.hp = Mathf.Max(obj.hp - damageAmount, 0);

    }
    
}
