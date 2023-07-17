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

        for (int j = 0; j < 8; j++) // For every row
        {
            for (int i = 0; i < 8; i++) // For every column
            {
                if (pieceIndex < player1.GetNumPieces() && (i + j) % 2 == 0)
                {
                    grid[i, j] = pieces[pieceIndex];
                    pieceIndex++;
                } 
                else grid[i, j] = null;
                visualBoard[i, j] = Instantiate(boardTilePrefab, transform);
                // work on this
                visualBoard[i, j].GetComponent<BoardSquareScript>().SetPosition(new Vector2Int(i, j));
                if ((i + j) % 2 == 0) visualBoard[i, j].GetComponent<BoardSquareScript>().ChangeSprite();
                visualBoard[i, j].transform.position = new Vector3(i - 3.5f, j - 3.5f);//new Vector3(3.5f - j, 3.5f - i);

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

    /// <summary>
    /// Using a piece's location, check if any of the diagonal neighboring spaces are available.
    /// Gets available locations for piece to move and returns as a list
    /// </summary>
    /// <param name="piece">The current piece being played</param>
    /// <returns>List of open locations</returns>
    public List<Vector2Int> GetAvailableSpaces(PieceBehaviorScript piece)
    {
        List<Vector2Int> availableSpaces = new List<Vector2Int>();
        Vector2Int pos = piece.GetPosition();

        // Check if the position is within the grid, can probably be removed
        if (pos.x >= 8 || pos.y < 0 || pos.y >= 8 || pos.x < 0)
            return availableSpaces; // return no available spaces

        /// TODO:
        /// Add behavior for when the diagonal spaces have enemies inside

        // If the current piece is a king (can move forward and backward)
        if (piece.isKing)
        {
            // check the lower bounds
            if (pos.x > 0 && pos.y > 0)
            {
                // Add the bottom left square
                availableSpaces.Add(new Vector2Int(pos.x - 1, pos.y - 1));
            }
            if (pos.x < 7 && pos.y > 0)
            {
                // Add the bottom right square
                availableSpaces.Add(new Vector2Int(pos.x + 1, pos.y - 1));
            }
        }

        // General Case:
        // The position is in the middle of the board ( not on the top row or left/right columns)
        if (pos.x < 0 && pos.y < 7)
            // add the upper left square
            availableSpaces.Add(new Vector2Int(pos.x - 1, pos.y + 1));

        if (pos.x < 7 && pos.y < 7)
            // add the upper right square
            availableSpaces.Add(new Vector2Int(pos.x + 1, pos.y + 1));

        return availableSpaces;
    }

    // CanMove or MovePiece
    /// <summary>
    /// If the space is available, move the current piece's location to the one where is was dropped (posotionDropped).
    /// Internally changes the Grid to reflect new position of piece if space is available.
    /// </summary>
    /// <param name="piece">Current piece being played/dropped</param>
    /// <param name="positionDropped">Position where it was dropped (board tile)</param>
    /// <returns>True if successful, false otherwise</returns>
    public bool MovePiece(PieceBehaviorScript piece, Vector2Int positionDropped)
    {
        // Check the available spaces from GetAvailableSpaces
        List<Vector2Int> spaces = GetAvailableSpaces(piece);

        // If no available spaces
        if (spaces.Count == 0) return false;

        // if positionDropped is not in the AvailableSpaces then return false
        if (spaces.Contains(positionDropped)) return false;

        // else we can change the grid and return true
        grid[positionDropped.x, positionDropped.y] = piece.gameObject;
        grid[piece.GetPosition().x, piece.GetPosition().y] = null;
        piece.SetPosition(new Vector2Int(positionDropped.x, positionDropped.y));
        return true;
    }
}
