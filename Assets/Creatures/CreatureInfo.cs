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



[CreateAssetMenu(fileName = "CreatureInfo", menuName = "Creatures")]
public class CreatureInfo : ScriptableObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Header("Basic info")]
    public string Name;
    public CreatureType type;
    public CreatureRole role;

    [Header("Stats Info")]
    public int attack;
    public int defense;
    public int hp;

    [Header("Moveset")]
    public CreatureMove[] moves;





}
