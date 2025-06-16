using UnityEngine;

[CreateAssetMenu(fileName = "BasiicMoveBA", menuName = "Scriptable Objects/BattleActions/BasiicMoveBA")]
public class BasiicMoveBA : AbstractBattleActionSO
{

    public override void Act(BattleFieldMB battlefield, GameObject[] performers, GameObject[] targets)
    {
        GameObject unit = performers[0];
        GameObject targetCell = targets[0];
        BasicMove(unit, targetCell);

    }


    public void BasicMove(GameObject unit, GameObject targetCell) {
        
        unit.transform.SetParent(targetCell.transform);
    }
        
}
