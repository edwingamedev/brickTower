using System;
using UnityEngine;

namespace EdwinGameDev
{
    [CreateAssetMenu(menuName = "Edwin Game Dev/GameBounds")]
    public class GameGrid : ScriptableObject
    {
        public GameObject gridPiece;
        public int gridMinX;
        public int gridMaxX;
        public int gridMinY;
        public int gridMaxY;

        private int gridSizeY => Math.Abs(gridMinY) + gridMaxY;
        private int gridSizeX => Math.Abs(gridMinX) + gridMaxX;
        private GridUnit[,] fullGrid;

        /// <summary>
        /// Creates a grid of sized based off of gridSizeX and gridSizeY public variables
        /// </summary>
        public void CreateGrid(Transform gridTransform)
        {
            fullGrid = new GridUnit[gridSizeX, gridSizeY];

            for (int y = 0; y < gridSizeY; y++)
            {
                for (int x = 0; x < gridSizeX; x++)
                {
                    GridUnit newGridUnit = new GridUnit(gridPiece, gridTransform, x, y);
                    fullGrid[x, y] = newGridUnit;
                }
            }
        }

        public bool IsInBounds(Vector2Int coordToTest)
        {
            if (coordToTest.x < gridMinX || coordToTest.x >= gridMaxX || coordToTest.y < gridMinY)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsPosEmpty(Vector2Int coordToTest)
        {
            if (coordToTest.y >= gridMaxY)
            {
                return true;
            }

            if (fullGrid[coordToTest.x, coordToTest.y].isOccupied)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckIfCollides(Vector2Int coordToTest, float distance, Piece[] blockPieces)
        {
            RaycastHit2D raycast = Physics2D.Raycast(coordToTest, Vector2.down, distance);
            bool sameBlockCollision = false;

            if (raycast)
            {
                for (int i = 0; i < blockPieces.Length; i++)
                {
                    if (sameBlockCollision)
                        break;

                    sameBlockCollision = raycast.collider == blockPieces[i].col;
                }

                if (!sameBlockCollision)
                    Debug.Log($"Collided {raycast.transform.name}: {raycast.transform.position}");
            }

            return !sameBlockCollision && raycast;
        }

        /// <summary>
        /// Called when a piece is set in place. Sets the grid location to an occupied state.
        /// </summary>
        public void OccupyPos(Vector2Int coords, GameObject tileGO)
        {
            fullGrid[coords.x, coords.y].isOccupied = true;
            fullGrid[coords.x, coords.y].tileOnGridUnit = tileGO;
        }
    }
}