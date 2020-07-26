using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EdwinGameDev
{
    public class Block : MonoBehaviour
    {
        public BlockType blockType;
        [HideInInspector] public Piece higherPiece;
        [SerializeField] private ScriptableEvent onBlockSet;
        [SerializeField] private ScriptableEvent onBlockFellOff;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private GameGrid gameGrid;

        private Piece[] pieces;
        private int rotationIndex { get; set; }
        private Vector2Int[,] offset;

        private RigidbodyType2D previousBodyType = RigidbodyType2D.Kinematic;
        private bool previousSimulated = false;

        [HideInInspector]
        public bool fellOff = false;
        private bool isPlayableBlock = true;


        private void Update()
        {
            if (isPlayableBlock && !fellOff && gameGrid.HasFellOffBounds(pieces[0].transform.position))
            {
                BlockFellOff();
            }
        }

        public void DisableBlock()
        {
            isPlayableBlock = false;
            DisablePhysics();
        }

        public void EnableBlock()
        {
            isPlayableBlock = true;
            ResumePhysics();
        }

        public void ResumePhysics()
        {
            rb.simulated = previousSimulated;
            rb.bodyType = previousBodyType;
        }

        public void EnablePhysics()
        {
            previousSimulated = rb.simulated;
            previousBodyType = rb.bodyType;

            rb.simulated = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        public void DisablePhysics()
        {
            previousSimulated = rb.simulated;
            previousBodyType = rb.bodyType;

            rb.simulated = false;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        public Piece GetHighestPiecePosition()
        {
            higherPiece = pieces.First(pi => pi.transform.position.y == pieces.Max(p => p.transform.position.y));
            return higherPiece;
        }

        public void Build(Vector2Int spawnPos, BlockType blockType, Piece[] pieces, Vector2Int[,] offset)
        {
            transform.name = $"Block {blockType}";

            this.blockType = blockType;
            this.pieces = pieces;
            this.offset = offset;
        }

        public bool MoveBlock(Vector2 movement)
        {

            for (int i = 0; i < pieces.Length; i++)
            {
                MovementRestriction movementRestriction = pieces[i].CanPieceMove(pieces, movement, movement + new Vector2(pieces[i].transform.position.x, pieces[i].transform.position.y));

                switch (movementRestriction)
                {
                    case MovementRestriction.FellOff:
                        PlaceBlock();

                        BlockFellOff();
                        return false;

                    case MovementRestriction.CannotMove:
                        Debug.Log("Cant Go there!");

                        if (movement.y < 0)
                        {
                            Debug.Log("Placed!");
                            PlaceBlock();
                        }
                        return false;
                    default:
                    case MovementRestriction.CanMove:
                        break;
                }
            }

            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i].MoveTile(movement);
            }

            return true;
        }
        private void BlockFellOff()
        {
            if (fellOff)
                return;

            fellOff = true;

            Debug.Log("BlockFellOff");

            onBlockFellOff.Trigger();
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
                pieces[i].RotateTile(pieces[0].transform.position, clockwise);
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
                if (CanMovePiece(pieces, endOffset))
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
        private bool CanMovePiece(Piece[] blockPieces, Vector2Int movement)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                MovementRestriction movementRestriction = pieces[i].CanPieceMove(pieces, movement, movement + new Vector2(pieces[i].transform.position.x, pieces[i].transform.position.y));

                if (movementRestriction == MovementRestriction.CannotMove)
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
        /// Sets the block in its permanent location.
        /// </summary>
        private void PlaceBlock()
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                if (!pieces[i].PlacePiece())
                {
                    Debug.Log("GAME OVER!");
                    return;
                }
            }

            EnablePhysics();

            onBlockSet.Trigger();
        }
    }
}