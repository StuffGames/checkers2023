using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorScript : MonoBehaviour
{
    public int numOfPieces;
    private int numPiecesTaken;

    private GameObject[] pieces;

    // Reference Game script
    public GameManagerScript game;

    // Reference Grid script
    public GridBehaviorScript grid;

    public GameObject piecePrefab;

    public int GetNumPieces()
    {
        return numOfPieces;
    }
    public int GetPiecesTaken()
    {
        return numPiecesTaken;
    }

    public GameObject[] GetPieces()
    {
        return pieces;
    }

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
            pieces[i] = Instantiate(piecePrefab, transform);
        }
        return pieces;
    }
}
