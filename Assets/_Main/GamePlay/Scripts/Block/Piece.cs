using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    public enum MovementRestriction
    {
        CanMove,
        FellOff,
        CannotMove
    }

    public class Piece : MonoBehaviour
    {
        //public Vector2 pieceCoordinates => transform.position;
        [SerializeField] private SpriteRenderer spriteRenderer;
        public GameGrid gameGrid;
        public Collider2D col;
        public float collisionDistance = 0.1f;

        public void SetSprite(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }

        /// <summary>
        /// Checks to see if the tile can be moved to the specified positon.
        /// </summary>
        /// <param name="endPos">Coordinates of the position you are trying to move the tile to</param>
        public MovementRestriction CanPieceMove(Piece[] blockPieces, Vector2 movementDirection, Vector2 endPos)
        {
            if (gameGrid.HasFellOffBounds(endPos))
            {
                return MovementRestriction.FellOff;
            }

            if (!gameGrid.IsInBounds(endPos))
            {
                return MovementRestriction.CannotMove;
            }

            if (gameGrid.CheckIfCollides(endPos, collisionDistance, movementDirection, blockPieces))
            {
                return MovementRestriction.CannotMove;
            }                

            return MovementRestriction.CanMove;
        }

        /// <summary>
        /// Sets the tile in it's current position
        /// </summary>
        public bool PlacePiece()
        {
            if (transform.position.y >= gameGrid.currentGridTop)
            {
                return false;
            }

            return true;
            //gameGrid.OccupyPos(pieceCoordinates, gameObject);
        }

        /// <summary>
        /// Moves the tile by the specified amount
        /// </summary>
        public void MoveTile(Vector2 movement)
        {
            Vector2 endPos = new Vector2(transform.position.x, transform.position.y) + movement;
            UpdatePosition(endPos);
        }

        /// <summary>
        /// Sets some new variables at the new position
        /// </summary>
        public void UpdatePosition(Vector2 newPos)
        {
            //pieceCoordinates = newPos;
            gameObject.transform.position = new Vector2(newPos.x, newPos.y);
        }

        /// <summary>
        /// Rotates the tile by 90 degrees about the origin tile.
        /// </summary>
        public void RotateTile(Vector2 originPos, bool clockwise)
        {
            Vector2 relativePos = new Vector2(transform.position.x, transform.position.y) - originPos;
            Vector2[] rotMatrix = clockwise ? new Vector2[2] { new Vector2(0, -1), new Vector2(1, 0) }
                                               : new Vector2[2] { new Vector2(0, 1), new Vector2(-1, 0) };
            float newXPos = rotMatrix[0].x * relativePos.x + rotMatrix[1].x * relativePos.y;
            float newYPos = rotMatrix[0].y * relativePos.x + rotMatrix[1].y * relativePos.y;
            Vector2 newPos = new Vector2(newXPos, newYPos);

            newPos += originPos;
            UpdatePosition(newPos);
        }

    }
}