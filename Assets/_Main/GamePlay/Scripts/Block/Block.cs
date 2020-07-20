using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    public class Block : MonoBehaviour
    {
        public BlockType blockType;
        private Piece[] pieces;
        private int rotationIndex { get; set; }
        private Vector2Int[,] offset;
        public ScriptableEvent onBlockSet;

        private void Awake()
        {

        }

        public void Build(Vector2Int spawnPos, BlockType blockType, Piece[] pieces, Vector2Int[,] offset)
        {
            transform.name = $"Block {blockType}";
                        
            this.blockType = blockType;
            this.pieces = pieces;
            this.offset = offset;
        }

        public bool MoveBlock(Vector2Int movement)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (!pieces[i].CanTileMove(movement + pieces[i].pieceCoordinates))
                {
                    Debug.Log("Cant Go there!");
                    if (movement == Vector2Int.down)
                    {
                        PlacePiece();
                    }
                    return false;
                }
            }

            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i].MoveTile(movement);
            }

            return true;
        }

        public void Rotate()
        {
            RotatePiece(true, true);
        }

        /// <summary>
        /// Rotates the piece by 90 degrees in specified direction. Offest operations should almost always be attempted,
        /// unless you are rotating the piece back to its original position.
        /// </summary>
        public void RotatePiece(bool clockwise, bool shouldOffset)
        {
            int oldRotationIndex = rotationIndex;
            rotationIndex += clockwise ? 1 : -1;
            rotationIndex = Mod(rotationIndex, 4);

            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i].RotateTile(pieces[0].pieceCoordinates, clockwise);

            }

            if (!shouldOffset)
            {
                return;
            }

            bool canOffset = CanOffset(oldRotationIndex, rotationIndex);

            if (!canOffset)
            {
                RotatePiece(!clockwise, false);
            }
        }

        private bool CanOffset(int oldRotationIndex, int rotationIndex)
        {
            Vector2Int offsetVal1, offsetVal2, endOffset;

            endOffset = Vector2Int.zero;

            bool movePossible = false;

            for (int testIndex = 0; testIndex < 5; testIndex++)
            {
                offsetVal1 = offset[testIndex, oldRotationIndex];
                offsetVal2 = offset[testIndex, rotationIndex];
                endOffset = offsetVal1 - offsetVal2;
                if (CanMovePiece(endOffset))
                {
                    movePossible = true;
                    break;
                }
            }

            if (movePossible)
            {
                MoveBlock(endOffset);
            }
            else
            {
                Debug.Log("Move impossible");
            }
            return movePossible;
        }

        /// <summary>
        /// Checks if the piece is able to be moved by the specified amount. A piece cannot be moved if there
        /// is already another piece there or the piece would end up out of bounds.
        /// </summary>
        private bool CanMovePiece(Vector2Int movement)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (!pieces[i].CanTileMove(movement + pieces[i].pieceCoordinates))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Mod operation that works for positive and negative values.
        /// </summary>
        private int Mod(int x, int m)
        {
            return (x % m + m) % m;
        }

        /// <summary>
        /// Sets the piece in its permanent location.
        /// </summary>
        private void PlacePiece()
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (!pieces[i].PlacePiece())
                {
                    Debug.Log("GAME OVER!");
                    return;
                }
            }

            onBlockSet.Trigger();
        }
    }
}