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

    /// <summary>
    /// Array of Board Squares that visualize the game board
    /// </summary>
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

        GameObject[] pieces = player1.GetPieces();
        int pieceIndex = 0;

        for (int i = 0; i < 8; i++) // For every row
        {
            for (int j = 0; j < 8; j++) // For every column
            {
                if (pieceIndex < player1.GetNumPieces() && (i + j) % 2 == 0)
                {
                    grid[j, i] = pieces[pieceIndex];
                    pieceIndex++;
                } 
                else grid[j, i] = null;
                visualBoard[j, i] = Instantiate(boardTilePrefab, transform);
                if ((i + j) % 2 == 0) visualBoard[j, i].GetComponent<BoardSquareScript>().ChangeSprite();
                visualBoard[j, i].transform.position = new Vector3(3.5f - j, 3.5f - i);

            }
        }
        return grid;
    }

    /// <summary>
    /// Get the grid array
    /// </summary>
    /// <returns>2D GameObject Array</returns>
    public GameObject[,] GetGrid()
    {
        return grid;
    }

    /// <summary>
    /// Get the visual board squares (BoardSquare prefabs)
    /// </summary>
    /// <returns>2D array of BoardSquare prefabs</returns>
    public GameObject[,] GetVisualBoard()
    {
        return visualBoard;
    }

    // GetAvailableSpaces()

    // CanMove or MovePiece
}
