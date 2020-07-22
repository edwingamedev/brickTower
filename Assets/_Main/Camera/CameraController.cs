using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    public class CameraController : MonoBehaviour
    {
        public GameContainer gameContainer;
        public Transform spawnPoint;
        public bool isLerping = false;
        private Vector3 oldPosition;
        private Vector3 newPosition;

        public float movementTime = 5;
        public float lerpValue = 0;

        public void MoveUp()
        {
            if (!isLerping && gameContainer.CheckTowerHeight())
            {
                spawnPoint.Translate(Vector3.up * 1);

                oldPosition = transform.position;
                newPosition = oldPosition + Vector3.up * 1;
                isLerping = true;
            }
        }

        void Update()
        {
            if (isLerping)
            {
                if (lerpValue < 1)
                {
                    lerpValue += Time.deltaTime / movementTime;
                    transform.position = Vector3.Lerp(oldPosition, newPosition, lerpValue);
                }
                else
                {
                    lerpValue = 0;
                    isLerping = false;
                }
            }
        }
    }
}