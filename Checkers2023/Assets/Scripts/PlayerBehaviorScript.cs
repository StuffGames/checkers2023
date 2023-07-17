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

    // Main Camera
    public Camera mainCamera;

    // Mouse position (vector)
    private Vector2 mousePosition;

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
        if (numOfPieces <= 0) return false;
        if (id < 0 || id > pieces.Length) return false;
        GameObject pieceToDelete = pieces[id];
        if (pieceToDelete == null) return false;

        pieces[id] = null;
        Destroy(pieceToDelete);
        numOfPieces--;
        return true;
    }

    /// <summary>
    /// Construct the number of pieces for the player to have. The piecePrefab gets instantiated then added to the array.
    /// It becomes the parent of the current player object.
    /// </summary>
    /// <returns>The array of peices for the player</returns>
    public GameObject[] ConstructPieces()
    {
        pieces = new GameObject[numOfPieces]; // numOfPieces should be 12
        for (int i = 0; i < numOfPieces; i++)
        {
            GameObject newPiece = Instantiate(piecePrefab, transform);
            // Add stuff to the new piece before adding to the array
            newPiece.name = "Piece " + (i + 1);
            PieceBehaviorScript p = newPiece.GetComponent<PieceBehaviorScript>();
            p.SetID(i);
            pieces[i] = newPiece;
        }
        return pieces;
    }

    private void Update()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // When mouse clicked, check if piece selected
        
        if (Input.GetMouseButtonDown(0))
        {
            // Create raycast to see if mouse is over game piece

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector3.zero);

            // if it is over game piece
            if (hit.collider is not null)
            {
                // Select piece clicked (behavior happens on the script attached to piece)
                PieceBehaviorScript piece = hit.transform.GetComponent<PieceBehaviorScript>();

                foreach (GameObject p in pieces)
                {
                    p.GetComponent<PieceBehaviorScript>().isSelected = false;
                }

                piece.isSelected = true;

                //hit.transform.position = mousePosition;
            }
            // add behavior for clicking on available square to move to

            // else deselecting piece
            else
            {
                foreach (GameObject p in pieces)
                {
                    p.GetComponent<PieceBehaviorScript>().isSelected = false;
                }
            }
        }
    }
}
