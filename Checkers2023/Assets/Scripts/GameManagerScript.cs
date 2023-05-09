using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Get the current player and grid
    public PlayerBehaviorScript player1;
    public GridBehaviorScript grid;

    private void Start()
    {
        // Start by constructing the player tiles and the grid
        GameObject[] player1Pieces = player1.ConstructPieces();
        foreach (GameObject piece in player1Pieces)
        {
            Debug.Log("Piece: " + piece.GetComponent<PieceBehaviorScript>().GetID());
        }

        GameObject[,] gameGrid = grid.ConstructGrid(player1);
        GameObject[,] visualBoard = grid.GetVisualBoard();
        for (int i = 0; i < gameGrid.GetLength(0); i++)
        {
            for (int j = 0; j < gameGrid.GetLength(0); j++)
            {
                //Debug.Log(i + ", "+ j);
                GameObject gridSquare = gameGrid[i,j];
                if (gridSquare != null)
                {
                    PieceBehaviorScript piece = gridSquare.GetComponent<PieceBehaviorScript>();
                    Debug.Log("GridSquare: " + piece.GetID());
                    piece.transform.position = visualBoard[i, j].transform.position; // Maybe just switch this to Construct Grid
                }
                else
                {
                    Debug.Log("GridSquare: null");
                }
            }
        }
    }
}
