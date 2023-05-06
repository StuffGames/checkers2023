using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehaviorScript : MonoBehaviour
{
    // Game Piece reference
    public GameObject piecePrefab; // probably unnecessary

    // Board Tile prefab
    public GameObject boardTilePrefab;

    /// <summary>
    /// Array of Game Piece objects to represent internal grid
    /// </summary>
    private GameObject[,] grid; // maybe change to Transform[] or PieceBehaviorScript[] later

    private GameObject[,] visualBoard;

    /// <summary>
    /// Constructs a 8x8 array of GameObjects to represent the grid. Contructs another 8x8 array to visualize the board. 
    /// Board Squares are instantiated and then moved to their proper positions.
    /// Initializes a starting game state using the pieces from player1.
    /// </summary>
    /// <param name="player1">Player to use to grab pieces to place on board</param>
    /// <returns>The grid fully initialized with beginning game state</returns>
    public GameObject[,] ConstructGrid(PlayerBehaviorScript player1)
    {
        grid = new GameObject[8, 8];
        visualBoard = new GameObject[8, 8];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((i + j) < (player1.GetNumPieces() *2) /*should be 24*/ && i + j % 2 == 0) grid[i, j] = player1.GetPieces()[i];
                else grid[i, j] = null;
                visualBoard[i, j] = Instantiate(boardTilePrefab, transform);
                if ((i + j) % 2 == 0) visualBoard[i, j].GetComponent<BoardSquareScript>().changeSprite();
                visualBoard[i, j].transform.position = new Vector3(3.5f - i, 3.5f - j);
            }
        }
        return grid;
    }

    public GameObject[,] getGrid()
    {
        return grid;
    }

    public GameObject[,] getVisualBoard()
    {
        return visualBoard;
    }

    // GetAvailableSpaces()

    // CanMove or MovePiece
}
