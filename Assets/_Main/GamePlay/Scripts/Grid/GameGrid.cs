using System;
using UnityEngine;

namespace EdwinGameDev
{
    [CreateAssetMenu(menuName = "Edwin Game Dev/GameBounds")]
    public class GameGrid : ScriptableObject
    {
        public int gridMinX;
        public int gridMaxX;
        public int gridMinY;
        public int gridMaxY;

        public bool HasFellOffBounds(Vector2 coordToTest)
        {
            return coordToTest.y < gridMinY;
        }

        public bool IsInBounds(Vector2 coordToTest)
        {
            if (coordToTest.x < gridMinX || coordToTest.x >= gridMaxX)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckIfCollides(Vector2 coordToTest, float distance, Piece[] blockPieces)
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
    }
}