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
    public  string move1;
    public string move2;
    public string move3;
    public string move4;
    public string move5;
    public string move6;





}
