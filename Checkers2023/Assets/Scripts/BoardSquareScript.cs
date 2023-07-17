using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSquareScript : MonoBehaviour
{
    public SpriteRenderer currentSprite;

    [SerializeField] private Vector2Int position;

    public Sprite blueSqaure;
    public Sprite purpleSquare;

    /// <summary>
    /// Changes the sprite from blue to purple, or purple to blue depending on current sprite.
    /// </summary>
    public void ChangeSprite ()
    {
        currentSprite.sprite = (currentSprite.sprite == blueSqaure) ? purpleSquare : blueSqaure;
    }

    public Vector2Int GetPosition()
    {
        return position;
    }

    public void SetPosition(Vector2Int pos)
    {
        // check if empty and stuff
        position = pos;
    }
}
