using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorScript : MonoBehaviour
{

    [SerializeField] private int numOfPieces;
    private int numPiecesTaken;

    // Maybe change to Transform[] or PieceBehaviorScript[] later
    private GameObject[] pieces;

    // Reference Game script
    public GameManagerScript game;

    // Reference Grid script
    public GridBehaviorScript grid;

    // Game piece
    public GameObject piecePrefab;

    /// <summary>
    /// Returns the current number of pieces the player has
    /// </summary>
    /// <returns></returns>
    public int GetNumPieces()
    {
        return numOfPieces;
    }
    /// <summary>
    /// Retrieve the number of pieces taken by player
    /// </summary>
    /// <returns>int representing number of taken pieces</returns>
    public int GetPiecesTaken()
    {
        return numPiecesTaken;
    }

    /// <summary>
    /// Adds to player's taken pieces
    /// </summary>
    public void AddTakenPiece()
    {
        numPiecesTaken++;
    }

    /// <summary>
    /// Returns pieces array from Player object
    /// </summary>
    /// <returns>Array of GameObjects Representing the Pieces</returns>
    public GameObject[] GetPieces()
    {
        return pieces;
    }

    /// <summary>
    /// Deletes the piece from the board and removes it from the player's pieces
    /// </summary>
    /// <param name="id">ID of the piece (0 indexed)</param>
    /// <returns>True if succesfully deleted, false if unable to delete</returns>
    public bool DeletePiece(int id)
    {
        GameObject pieceToDelete = pieces[id];
        if (pieceToDelete == null) return false;

        pieces[id] = null;
        Destroy(pieceToDelete);
        return true;
    }

    public GameObject[] ConstructPieces()
    {
        pieces = new GameObject[numOfPieces]; // numOfPieces should be 12
        for (int i = 0; i < 12; i++)
        {
            GameObject newPiece = Instantiate(piecePrefab, transform);
            // Add stuff to the new piece before adding to the array
            pieces[i] = newPiece;
        }
        return pieces;
    }
}
