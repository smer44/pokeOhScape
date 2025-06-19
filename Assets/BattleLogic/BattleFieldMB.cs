using UnityEngine;
using System.Collections.Generic;

public class BattleFieldMB : MonoBehaviour
{

    public string name;
    [SerializeField]
    public GameObject[] grid;
    public GameObject cellPrefab;
    public GameObject wallPrefab;
    public BattleActionMenuUI battleActionMenu;

    public Dictionary<string, List<GameObject>> teams;


    public string currentTeam;
    //other teams are concidered to be enemy teams.
    //public string enemyTeam;
    public BattleFieldState fieldState;

    public HashSet<GameObject> selectedPerformers;
    public HashSet<GameObject> selectedTargets;
    public AbstractBattleActionSO selectedAction;

    public int width;
    public int height;
    private int[] nrx = new int[] { -1, 1, 0, 0 };
    private int[] nry = new int[] { 0, 0, -1, 1 };


    private int[] nrdx = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };
    private int[] nrdy = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };


    private GameObject battleActionMenuGO;



    GameObject GetCell(int x, int y)
    {

        return grid[ToOneDimIndex(x, y)];
    }

    GameObject GetCell(Vector2Int xy)
    {

        return grid[ToOneDimIndex(xy.x, xy.y)];
    }

    int ToOneDimIndex(int x, int y)
    {
        return y * width + x;
    }

    public Vector2Int ToTwoDimIndex(int index)
    {
        int y = index / width;
        int x = index % width;
        return new Vector2Int(x, y);
    }


    private void InitializeGridCellsIfEmpty()
    {
        for (int n = 0; n < grid.Length; n++)
        {

            Vector2Int xy = ToTwoDimIndex(n);
            GameObject cell = GetCell(xy);

            Vector3 pos = new Vector3(xy.x, 0, xy.y);

            GameObject currentCellPrefab = grid[n] == null ? cellPrefab : grid[n];
            GameObject instance = Instantiate(currentCellPrefab, pos, Quaternion.identity);
            instance.transform.SetParent(this.transform);
            grid[n] = instance;

        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateGridHeight();
        InitializeGridCellsIfEmpty();
        battleActionMenuGO = battleActionMenu.gameObject;

        //Debug.Log($"battleActionMenuGO: {battleActionMenuGO}");
        //battleActionMenuGO.SetActive(true);
        // If teams are not known, we update teams from field content.
        teams = UpdateTeams();
        PrintTeams(teams);

    }

    void UpdateGridHeight()
    {
        height = grid.Length / width + (grid.Length % width > 0 ? 1 : 0);
    }



    // Update is called once per frame
    void Update()
    {
        UpdateLeftMouseButton();
    }


    public List<GameObject> GetNeighboursCells(int x, int y, bool includeDiagonal)
    {
        int[] dx = includeDiagonal ? nrdx : nrx;
        int[] dy = includeDiagonal ? nrdy : nry;
        List<GameObject> neighbours = new List<GameObject>();

        for (int j = 0; j < dy.Length; j++)
        {
            int ny = y + dy[j];

            if (0 <= ny && ny < height)
            {
                for (int i = 0; i < dx.Length; i++)
                {
                    int nx = x + dx[i];
                    if (0 <= nx && nx < width)
                    {
                        neighbours.Add(GetCell(nx, ny));
                    }

                }

            }

        }
        return neighbours;
    }


    private void UpdateLeftMouseButton()
    {
        if (Input.GetMouseButtonDown(0))
        {


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
                //GameObject referenceObject = clickedObject
                Debug.Log($"Clicked on object: {clickedObject.name}, fieldState : {fieldState}");
                //if (fieldState == BattleFieldState.SelectingFirstPerformer)
                //{
                //Debug.Assert(performers.Count == 0, "Performers Hashtable is not empty!");
                //Debug.Assert(targets.Count == 0, "Targets Hashtable is not empty!");
                //Debug.Log("Selected first performer: " + clickedObject.name);
                //then check if it is valide performer
                //performers.Add()

                //}
                if (fieldState == BattleFieldState.SelectingFirstPerformer)
                {
                    battleActionMenuGO.SetActive(true);
                    battleActionMenu.firstPerformerName = clickedObject.name;

                }

            }
        }

    }


    public void MoveChildObject(int fromX, int fromY, int toX, int toY, GameObject childObject)
    {
        GameObject fromCell = GetCell(fromX, fromY);
        GameObject toCell = GetCell(toX, toY);

        childObject.transform.SetParent(toCell.transform);

    }


    public Dictionary<string, List<GameObject>> UpdateTeams()
    {
        Dictionary<string, List<GameObject>> unitsByTeam = new Dictionary<string, List<GameObject>>();

        foreach (GameObject cellObject in grid)
        {
            CellMB cell = cellObject.GetComponent<CellMB>();
            UnitMB unit = cell.GetUnitMBFromChildren();
            if (unit != null)
            {
                string team = unit.team;
                if (!unitsByTeam.ContainsKey(team))
                {
                    unitsByTeam[team] = new List<GameObject>();
                }
                unitsByTeam[team].Add(unit.gameObject);


            }
        }
        return unitsByTeam;
    }


    public void PrintTeams(Dictionary<string, List<GameObject>> teams)
    {
        foreach (var teamEntry in teams)
        {
            Debug.Log($"Team: {teamEntry.Key}, size: {teamEntry.Value.Count}");
            foreach (GameObject unit in teamEntry.Value)
            {
                Debug.Log($" - Unit: {unit}");
            }
        }
    }


    void InitHashSets()
    {
        selectedPerformers = new HashSet<GameObject>();
        selectedTargets = new HashSet<GameObject>();
    }

    void ValidateHashSetsEmpty()
    {
        Debug.Assert(selectedPerformers.Count == 0, "BattleFieldMB:Performers Hashtable is not empty!");
        Debug.Assert(selectedTargets.Count == 0, "BattleFieldMB:Targets Hashtable is not empty!");
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
        selectedAction = actionInput;
    }

    /// <summary>
    /// Checks if currently selected action need more performers
    /// If action.maxPerformers == 0 it is interpreted as "all" and returned false
    /// Returns true, if count of selected performers (performers.Count) is less then action performers
    /// or selected performers is less then size of the current team so you really can select more.
    /// </summary>
    /// 
    /// TODO - mechanics of nessesary / or only allowed  performers can be done here. 
    public bool NeedMorePerformers()
    {

        return selectedAction.maxPerformers > 0 && selectedPerformers.Count < selectedAction.maxPerformers && selectedPerformers.Count < teams[currentTeam].Count;

    }

    public bool NeedMoreTargets()
    {
        return selectedAction.maxTargets > 0 && selectedPerformers.Count < selectedAction.maxPerformers && selectedPerformers.Count < CountEnemyTeamMembers(GetCurrentEnemyTeamNames());
    }

    /// <summary>
    /// This method auto- selects other performers, if it is
    /// nessesary follows after selecting the first performer.
    /// Currently, if selectedAction.maxPerformers == 0 
    /// is interpreted as "all", so all current team members
    /// will be selected as performers
    /// </summary>
    public void AutoSelectPerformers()
    {
        if (selectedAction.maxPerformers == 0)
        {
            foreach (var unit in teams[currentTeam])
            {
                selectedPerformers.Add(unit);
            }

        }

    }

    public int CountEnemyTeamMembers(List<string> teamNames) {
        int count = 0;
        foreach (string team in teamNames)
        {
            count += teams[team].Count;
        }
        return count;
    }

    public List<string> GetCurrentEnemyTeamNames()
    {
        List<string> enemyTeams = new List<string>();
        foreach (var team in teams.Keys)
        {
            if (team != currentTeam)
            {
                enemyTeams.Add(team);
            }

        }
        return enemyTeams;
    }
    
    


    /// <summary>
    /// This method auto- selects  targets, if it is
    /// nessesary follows for given battle action.
    /// Currently, this works only if selectedAction.maxTargets == 0 
    /// is interpreted as "all", so all enemy teams are auto-selected as targets
    /// </summary>
    public void AutoSelectTargets()
    {
        if (selectedAction.maxTargets == 0)
        {
            var enemyTeams = GetCurrentEnemyTeamNames();
            foreach (var team in enemyTeams) {
                foreach (var unit in teams[team])
                {
                    selectedTargets.Add(unit);
                }
            }


        }

    }



}
