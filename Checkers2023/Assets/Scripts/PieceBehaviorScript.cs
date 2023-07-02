using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceBehaviorScript : MonoBehaviour
{
    /// <summary>
    /// Collider of the piece
    /// </summary>
    //private Collider2D collider;

    /// <summary>
    /// The position of the piece relative to the board, 0-indexed
    /// </summary>
    private Vector2Int pos;

    /// <summary>
    /// Denotes if the current piece is selected by the player
    /// </summary>
    private bool isSelected;

    /// <summary>
    /// Denotes if the current piece is a king or normal
    /// </summary>
    public bool isKing;

    /// <summary>
    /// The id of the current piece (for lookup or something idk)
    /// </summary>
    [SerializeField] private int id = 0;

    private void Start()
    {
        pos = new Vector2Int(0, 0);
        isSelected = false;
        isKing = false;
    }

    private void Update()
    {
        // Logic for picking up / selecting tile and moving it

    }

    /// <summary>
    /// Set the id of the piece
    /// </summary>
    /// <param name="id">new ID</param>
    public void SetID(int id)
    {
        this.id = id;
    }
    /// <summary>
    /// Get the id of the piece
    /// </summary>
    /// <returns>the ID</returns>
    public int GetID ()
    {
        return id;
    }

    /// <summary>
    /// Set the current position of the piece on the board
    /// </summary>
    /// <param name="newPos">Position (x, y)</param>
    public void SetPosition(Vector2Int newPos)
    {
        // edit position, maybe just use transform
        pos = newPos;
    }

    /// <summary>
    /// Get the current position of the piece on the board
    /// </summary>
    /// <returns>Vector2Int of the position (x, y)</returns>
    public Vector2Int GetPosition()
    {
        return pos;
    }

}
