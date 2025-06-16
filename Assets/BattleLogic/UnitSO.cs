using UnityEngine;

[CreateAssetMenu(fileName = "UnitSO", menuName = "Scriptable Objects/UnitSO")]
public class UnitSO : ObjectWithHitPointsSO
{
    public int attack;
    public int defence;

    public UnitSO Copy()
    {
        UnitSO obj = ScriptableObject.CreateInstance<UnitSO>();
        obj.attack = this.attack;
        obj.defence = this.defence;
        obj.hitPoints = this.hitPoints;
        obj.unitName = unitName + "_copy";
        return obj;

    }
}
