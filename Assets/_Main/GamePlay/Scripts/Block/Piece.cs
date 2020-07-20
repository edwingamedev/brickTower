using EdwinGameDev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public Vector2Int pieceCoordinates;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    public GameGrid gameGrid;

    public void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    /// <summary>
    /// Checks to see if the tile can be moved to the specified positon.
    /// </summary>
    /// <param name="endPos">Coordinates of the position you are trying to move the tile to</param>
    public bool CanTileMove(Vector2Int endPos)
    {
        if (!gameGrid.IsInBounds(endPos))
        {
            return false;
        }
        if (!gameGrid.IsPosEmpty(endPos))
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Sets the tile in it's current position
    /// </summary>
    public bool PlacePiece()
    {
        if (pieceCoordinates.y >= gameGrid.gridMaxY)
        {
            return false;
        }

        gameGrid.OccupyPos(pieceCoordinates, gameObject);
        return true;
    }

    /// <summary>
    /// Moves the tile by the specified amount
    /// </summary>
    public void MoveTile(Vector2Int movement)
    {
        Vector2Int endPos = pieceCoordinates + movement;
        UpdatePosition(endPos);
    }

    /// <summary>
    /// Sets some new variables at the new position
    /// </summary>
    public void UpdatePosition(Vector2Int newPos)
    {
        pieceCoordinates = newPos;
        gameObject.transform.position = new Vector2(newPos.x, newPos.y);
    }

    /// <summary>
    /// Rotates the tile by 90 degrees about the origin tile.
    /// </summary>
    public void RotateTile(Vector2Int originPos, bool clockwise)
    {
        Vector2Int relativePos = pieceCoordinates - originPos;
        Vector2Int[] rotMatrix = clockwise ? new Vector2Int[2] { new Vector2Int(0, -1), new Vector2Int(1, 0) }
                                           : new Vector2Int[2] { new Vector2Int(0, 1), new Vector2Int(-1, 0) };
        int newXPos = (rotMatrix[0].x * relativePos.x) + (rotMatrix[1].x * relativePos.y);
        int newYPos = (rotMatrix[0].y * relativePos.x) + (rotMatrix[1].y * relativePos.y);
        Vector2Int newPos = new Vector2Int(newXPos, newYPos);

        newPos += originPos;
        UpdatePosition(newPos);
    }

}
