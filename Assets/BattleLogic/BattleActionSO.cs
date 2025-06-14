using UnityEngine;

//[CreateAssetMenu(fileName = "BattleAction", menuName = "Scriptable Objects/BattleAction")]
public abstract class BattleActionSO 
{
    public abstract void Act(BattleFieldSO field, UnitSO[] performers, UnitSO[] targets);
}
