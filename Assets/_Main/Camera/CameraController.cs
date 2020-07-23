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
        public float smoothTime = 1F;
        private Vector3 velocity = Vector3.zero;
        private Vector3 startingTargetPos;
        private Vector3 startingCameraPos;

        private void Start()
        {
            startingTargetPos = target.position;
            startingCameraPos = transform.position;
        }

        public void ResetCameraPos()
        {
            target.position = startingTargetPos;
            transform.position = startingCameraPos;
        }

        public void CheckTowerHeight()
        {
            Transform newPos = gameContainer.GetHighestBlock();

            if (newPos)
                target.position = new Vector3(startingTargetPos.x, startingTargetPos.y + Mathf.CeilToInt(newPos.position.y) - startingTargetPos.y);
        }

        void Update()
        {
            // Define a target position above and behind the target transform
            Vector3 targetPosition = target.TransformPoint(new Vector3(5, 9.5f, -10));

            // Smoothly move the camera towards that target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}