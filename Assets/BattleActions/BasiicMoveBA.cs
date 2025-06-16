using UnityEngine;

[CreateAssetMenu(fileName = "BasiicMoveBA", menuName = "Scriptable Objects/BasiicMoveBA")]
public class BasiicMoveBA : ScriptableObject
{

    public override void Act(BattleFieldMB battlefield, GameObject[] performers, GameObject[] targets)
    {
        GameObject unit = performers[0];
        GameObject targetCell = targets[0];
        bool wasDamage = BasicMove(unit, targetCell);

    }


    public void BasicMove(GameObject unit, GameObject targetCell) {
        
        unit.transform.SetParent(targetCell.transform);
    }
        
}
