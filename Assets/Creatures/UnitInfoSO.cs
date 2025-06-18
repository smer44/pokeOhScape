using UnityEngine;


public enum CreatureRole
{
    AttackDefense,
    Support,
    Conjuror

}

public enum CreatureType
{
    Water,
    Fire,
    Grass
}

public enum CreatureMove
{
    BasicAttack,
    Laser,
    CloseCombat,
    Buff,
    Decoy,
    Tower,
    SoloHeal,
    SmokeScreen,
    Move,
    Direct,
    DualSmack,
    Barrier,
    Tunnel,
    Breakdown,
    ZoneHeal,
    Focus,
    Flood,
    Cloud,
    Aerial,
    Poison,






}


[CreateAssetMenu(fileName = "UnitSO", menuName = "Scriptable Objects/UnitSO")]
//[CreateAssetMenu(fileName = "CreatureInfo", menuName = "Creatures")]
public class UnitSO : ObjectWithHitPointsSO
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Header("Basic info")]
    public CreatureType type;
    public CreatureRole role;

    [Header("Stats Info")]
    public int attack;
    public int defence;

    [Header("Moveset")]
    public CreatureMove[] moves;


    public UnitSO Copy()
    {
        UnitSO obj = ScriptableObject.CreateInstance<UnitSO>();
        obj.Name = this.Name + "_copy";
        obj.attack = this.attack;
        obj.defence = this.defence;
        obj.hp = this.hp;
        obj.moves = (CreatureMove[]) this.moves.Clone();
        return obj;


    }


}
