using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehaviorScript : MonoBehaviour
{
    // Game Piece reference
    public GameObject piecePrefab;

    // Board Tile prefab
    public GameObject boardTilePrefab;

    /// <summary>
    /// Array of Game Piece objects to represent internal grid
    /// </summary>
    private GameObject[,] grid; // maybe change to Transform[] or PieceBehaviorScript[] later

    public GameObject[,] ConstructGrid(PlayerBehaviorScript player1)
    {
        grid = new GameObject[8, 8];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((i + j) < 24 && i + j % 2 == 0) grid[i, j] = player1.GetPieces()[i];
                else grid[i, j] = null;
            }
        }
        return grid;
    }

    // GetAvailableSpaces()

    // CanMove or MovePiece
}
