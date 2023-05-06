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
            Debug.Log("Piece: " + piece.name);
        }

        GameObject[,] gameGrid = grid.ConstructGrid(player1);
        foreach (GameObject gridSquare in gameGrid)
        {
            Debug.Log("Grid Square: " + ((gridSquare == null) ? "null" : gridSquare.name));
        }

    }
}
