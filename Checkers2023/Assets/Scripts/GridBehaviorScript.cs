using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehaviorScript : MonoBehaviour
{
    // Create array of tiles or pieces (prefabs) idk yet i have to rethink some stuff
    public GameObject piecePrefab;

    private GameObject[,] grid;

    public GameObject[,] ConstructGrid(PlayerBehaviorScript player1)
    {
        grid = new GameObject[8, 8];
        for (int i = 0; i < 8;)
        {
            for (int j = 0; j < 8;)
            {
                if ((i / 2) >= 12) break;
                grid[i, j] = player1.GetPieces()[i / 2]; // CHANGE SINCE THIS IS PROBABLY REALLY WRONG
                j += 2;
            }
            i += 2;
        }
        return grid;
    }
}
