using UnityEngine;
using System.Collections.Generic;

public class BattleFieldMB : MonoBehaviour
{

    public string name;
    [SerializeField]
    public GameObject[] grid;
    public GameObject cellPrefab;
    public GameObject wallPrefab;
    public int width;
    public int height;
    private int[] nrx = new int[] { -1, 1, 0, 0 };
    private int[] nry = new int[] { 0, 0, -1, 1 };


    private int[] nrdx = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };
    private int[] nrdy = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };


    GameObject GetCell(int x, int y)
    {

     return   grid[ToOneDimIndex(x,y)];
    }

   GameObject GetCell(Vector2Int xy)
    {

     return   grid[ToOneDimIndex(xy.x,xy.y)];
    }    

    int ToOneDimIndex(int x, int y) {
        return y * width + x;
    }

    public Vector2Int ToTwoDimIndex(int index) {
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
    }

    void UpdateGridHeight() {
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
                        neighbours.Add(GetCell(nx,ny));
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
                Debug.Log("Clicked on object: " + clickedObject.name);

            }
        }

    }


    public void MoveChildObject(int fromX, int fromY, int toX, int toY, GameObject childObject)
    {
        GameObject fromCell = GetCell(fromX,fromY);
        GameObject toCell =  GetCell(toX,toY);

        childObject.transform.SetParent(toCell.transform);

    }
}
