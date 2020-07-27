using System.Collections;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using UnityEngine;

namespace EdwinGameDev
{
    [CreateAssetMenu(menuName = "Edwin Game Dev/GameBounds")]
    public class GameGrid : ScriptableObject
    {
        public int gridMinX;
        public int gridMaxX;

        private int gridMinY = 0;
        private int gridMaxY = 40;

        public int currentGridBottom;
        public int currentGridTop;

        public void ResetGrid()
        {
            currentGridBottom = gridMinY;
            currentGridTop = gridMaxY;
        }

        public void SetGridBottom(int bottom)
        {
            currentGridBottom = bottom;
        }

        /// <summary>
        /// Sets the start grid Y max position
        /// </summary>
        /// <param name="top"></param>
        public void SetStartGridTop(int top)
        {
            gridMaxY = top;
            SetCurrentGridTop(top);
        }

        /// <summary>
        /// Sets current grid Y max position
        /// </summary>
        /// <param name="top"></param>
        public void SetCurrentGridTop(int top)
        {
            currentGridTop = top;
        }

        public bool HasFellOffBounds(Vector2 coordToTest)
        {
            return coordToTest.y < currentGridBottom || coordToTest.x < gridMinX - 1 || coordToTest.x >= gridMaxX + 1;
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

        public bool CheckIfCollides(Vector2 centerCoord, float distance, Vector2 movementDirection, Piece[] blockPieces)
        {
            return VerticalCollisions(centerCoord, distance, Mathf.FloorToInt(movementDirection.y), blockPieces) ||
                    HorizontalCollisions(centerCoord, distance, Mathf.FloorToInt(movementDirection.x), blockPieces);
        }

        private bool VerticalCollisions(Vector3 centerCoord, float distance, int direction, Piece[] blockPieces)
        {
            direction = Mathf.Clamp(direction, -1, 1);

            float pieceColliderWidth = blockPieces[0].col.bounds.extents.x;
            float pieceColliderHeight = blockPieces[0].col.bounds.extents.y;
            bool sameBlockCollision = false;

            for (int i = 0; i < 3; i++)
            {
                Vector2 rayOrigin = new Vector2(centerCoord.x - pieceColliderWidth, centerCoord.y + pieceColliderHeight * direction);
                rayOrigin += Vector2.right * (pieceColliderWidth * i);

                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * direction, distance);

#if UNITY_EDITOR
                Debug.DrawRay(rayOrigin, Vector2.up * distance * direction, Color.white);
#endif
                if (hit)
                {
                    for (int j = 0; j < blockPieces.Length; j++)
                    {
                        if (sameBlockCollision)
                            break;

                        sameBlockCollision = hit.collider == blockPieces[j].col;
                    }

                    return !sameBlockCollision && hit;
                }
            }

            return sameBlockCollision;
        }
        private bool HorizontalCollisions(Vector3 centerCoord, float distance, int direction, Piece[] blockPieces)
        {
            direction = Mathf.Clamp(direction, -1, 1);

            float pieceColliderWidth = blockPieces[0].col.bounds.extents.x;
            float pieceColliderHeight = blockPieces[0].col.bounds.extents.y;
            bool sameBlockCollision = false;

            // Left
            for (int i = 0; i < 3; i++)
            {
                Vector2 rayOrigin = new Vector2(centerCoord.x + pieceColliderWidth * direction, centerCoord.y - pieceColliderHeight);
                rayOrigin += Vector2.up * (pieceColliderHeight * i);

                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * direction, distance);

#if UNITY_EDITOR
                Debug.DrawRay(rayOrigin, Vector2.right * distance * direction, Color.white);
#endif 

                if (hit)
                {
                    for (int j = 0; j < blockPieces.Length; j++)
                    {
                        if (sameBlockCollision)
                            break;

                        sameBlockCollision = hit.collider == blockPieces[j].col;
                    }

                    return !sameBlockCollision && hit;
                }
            }

            // Right

            return sameBlockCollision;
        }


    }
}