using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BattleFieldSO", menuName = "Scriptable Objects/BattleFieldSO")]
public class BattleFieldSO : ScriptableObject
{
    public string name;
    public GameObject[][] grid;

    private int[] nrx = new int[] { -1, 1, 0, 0 };
    private int[] nry = new int[] { 0, 0, -1, 1 };


    private int[] nrdx = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };
    private int[] nrdy = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };

    public List<GameObject> GetNeighboursCells(int x, int y, bool includeDiagonal)
    {
        int[] dx = includeDiagonal ? nrdx : nrx;
        int[] dy = includeDiagonal ? nrdy : nry;
        List<GameObject> neighbours = new List<GameObject>();

        for (int j = 0; j < dy.Length; j++)
        {
            int ny = y + dy[j];

            if (0 <= ny && ny < grid.Length)
            {
                for (int i = 0; i < dx.Length; i++)
                {
                    int nx = x + dx[i];
                    if (0 <= nx && nx < grid[ny].Length)
                    {
                        neighbours.Add(grid[ny][nx]);
                    }                    

                }

            }

        }
        return neighbours;
    }

}
