using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSquareScript : MonoBehaviour
{
    public SpriteRenderer currentSprite;

    public Sprite blueSqaure;
    public Sprite purpleSquare;

    /// <summary>
    /// Changes the sprite from blue to purple, or purple to blue depending on current sprite.
    /// </summary>
    public void changeSprite ()
    {
        currentSprite.sprite = (currentSprite.sprite == blueSqaure) ? purpleSquare : blueSqaure;
    }
}
