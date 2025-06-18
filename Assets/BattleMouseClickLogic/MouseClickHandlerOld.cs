using UnityEngine;
using System.Collections.Generic;

public class MouseClickHandler
{

    public BattleFieldState fieldState;
    public HashSet<GameObject> performers;
    public HashSet<GameObject> targets;

    public string currentTeam;

    public AbstractBattleActionSO action;


    private MouseClickHandler()
    {
        currentTeam = "player1";
        InitHashSets();
        fieldState = BattleFieldState.SelectingFirstPerformer;

    }

    public void ReceiveClickOn(GameObject obj)
    {
        if (fieldState == BattleFieldState.SelectingFirstPerformer)
        {
            AssertHashSetsEmpty();

            if (ValidateFirstPerformer(obj))
            {
                Debug.Log("Selected first performer: " + obj.name);
                performers.Add(obj);

            }
        
        }


    }

    void InitHashSets()
    {
        performers = new HashSet<GameObject>();
        targets = new HashSet<GameObject>();
    }

    void AssertHashSetsEmpty()
    {
        Debug.Assert(performers.Count == 0, "MouseClickHandler:Performers Hashtable is not empty!");
        Debug.Assert(targets.Count == 0, "MouseClickHandler:Targets Hashtable is not empty!");
    }


    /// <summary>
    /// Validating first performer, it just need to belong to a team, whose turn is currently in.
    /// </summary>
    public bool ValidateFirstPerformer(GameObject obj)
    {
        UnitMB unit = obj.GetComponent<UnitMB>();

        return currentTeam.Equals(unit.team);

    }

    public void SetCurrentAction(AbstractBattleActionSO actionInput)
    {
        action = actionInput;
    }

    public bool NeedMorePerformers()
    {
        return   action.maxPerformers >0 && performers.Count < action.maxPerformers;

    }

    public bool NeedMoreTargets()
    {
        return action.maxTargets >0 && targets.Count < action.maxTargets;

    }
    
}
