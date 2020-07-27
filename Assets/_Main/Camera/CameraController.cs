using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    public class CameraController : MonoBehaviour
    {
        public GameContainer gameContainer;
        public Transform spawnPoint;
        public Transform target;
        public GameGrid gameGrid;

        public float smoothTime = 1F;
        public Vector3 cameraOffSet = new Vector3(5, 6.5f, -10);
        public float cameraSize;

        private Camera camera;
        private Vector3 velocity = Vector3.zero;
        private Vector3 startingTargetPos;
        private Vector3 startingCameraPos;

        private int verticalThreshold = 5;
        private int previousHigherPosition = 0;


        private void Awake()
        {
            camera = GetComponent<Camera>();
            float screenRatio = (float)Screen.height / (float)Screen.width;
            camera.orthographicSize = cameraSize * screenRatio * .5f;
        }

        private void Start()
        {
            startingTargetPos = target.position;
            transform.position = target.TransformPoint(new Vector3(cameraOffSet.x, camera.orthographicSize - cameraOffSet.y, cameraOffSet.z));
            startingCameraPos = transform.position;

            // Sets grid top
            gameGrid.SetStartGridTop(Mathf.RoundToInt(camera.orthographicSize + transform.position.y));

            // SPAWN
            spawnPoint.position = new Vector3(spawnPoint.position.x, camera.orthographicSize + transform.position.y - 1.5f);
        }

        public void ResetCameraPos()
        {
            target.position = startingTargetPos;
            transform.position = startingCameraPos;
            previousHigherPosition = 0;

            gameGrid.ResetGrid();
        }

        public void CheckTowerHeight()
        {
            int highestPosition = gameContainer.GetHighestBlock();

            CalculateNewCameraPosition(highestPosition);
        }

        private void CalculateNewCameraPosition(int highestPosition)
        {
            if (highestPosition > previousHigherPosition + verticalThreshold)
            {
                int diff = highestPosition / verticalThreshold;
                float newPosition = startingTargetPos.y + (diff * verticalThreshold);

                target.position = new Vector3(startingTargetPos.x, newPosition);

                // Update highest position
                previousHigherPosition = diff * verticalThreshold;
                gameContainer.DisableBlockBelow(previousHigherPosition - verticalThreshold);
                //gameGrid.SetGridBottom(previousHigherPosition - 2);
            }
            else if (highestPosition <= previousHigherPosition)
            {
                int diff = highestPosition / verticalThreshold;
                float newPosition = (diff * verticalThreshold) - startingTargetPos.y;

                target.position = new Vector3(startingTargetPos.x, newPosition);

                //gameGrid.SetGridBottom(previousHigherPosition - 2);

                // Update highest position
                previousHigherPosition = diff * verticalThreshold;
            }

            // Sets grid top
            gameGrid.SetStartGridTop(Mathf.RoundToInt(spawnPoint.position.y + 1.5f));

            // min
            //camera.orthographicSize + transform.position.y - 1.5f
        }

        void Update()
        {
            // Define a target position above and behind the target transform
            Vector3 targetPosition = target.TransformPoint(new Vector3(cameraOffSet.x, camera.orthographicSize - cameraOffSet.y, cameraOffSet.z));

            // Smoothly move the camera towards that target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}