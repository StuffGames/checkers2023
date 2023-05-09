using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceBehaviorScript : MonoBehaviour
{

    private Vector2 pos; // could just be transform.position
    /// <summary>
    /// Denotes if the current piece is selected by the player
    /// </summary>
    private bool isSelected;
    /// <summary>
    /// Denotes if the current piece is a king or normal
    /// </summary>
    private bool isKing;
    /// <summary>
    /// The id of the current piece (for lookup or something idk)
    /// </summary>
    [SerializeField] private int id = 0;

    private void Start()
    {
        pos = new Vector2(0, 0);
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

    public void SetPosition(Vector2 newPos)
    {
        // edit position, maybe just use transform
        pos = newPos;
    }

}
