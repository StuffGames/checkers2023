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
    [SerializeField] private Vector2Int pos = new Vector2Int(0, 0);

    /// <summary>
    /// Denotes if the current piece is selected by the player
    /// </summary>
    public bool isSelected;

    /// <summary>
    /// Denotes if the current piece is a king or normal
    /// </summary>
    public bool isKing;

    /// <summary>
    /// The id of the current piece (for lookup or something idk)
    /// </summary>
    [SerializeField] private int id = 0;

    private GridBehaviorScript grid;

    private void Start()
    {
        //pos = new Vector2Int(0, 0);
        grid = GameObject.Find("Grid").GetComponent<GridBehaviorScript>();
        isSelected = false;
        isKing = false;
    }

    private void Update()
    {
        // Logic for picking up / selecting tile and moving it

        if (isSelected)
        {
            // move to mouse position
            if (Input.GetMouseButton(0))
            {
                // linear interpolation ?
                Vector2 mPos = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
                transform.position = mPos;
            }
            // else stay at board position (the correct board square)
            else
            {
                // use created grid to find board square at pos
                GameObject squarePos = grid.GetVisualBoard()[pos.x, pos.y]; //maybe use square.GetPosition to check if positions same?
                transform.position = squarePos.transform.position;
            }
        }

        // testing
        if (isSelected) transform.localScale = new Vector3(2f, 2f, 0);
        else transform.localScale = new Vector3(1.695f, 1.695f, 0);
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
