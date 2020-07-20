using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    public class Block : MonoBehaviour
    {
        private new Transform transform;
        public new Rigidbody2D rigidbody;

        // Starts with Kinematic type
        private bool hasPhysics = false;

        private Vector2 leftVector = new Vector2(-0.25f, 0);
        private Vector2 rightVector = new Vector2(0.25f, 0);

        public ScriptableEvent OnBlockCollided;

        public bool canTurn = true;

        // Falling
        private Vector2 downVector = new Vector2(0, -0.1f);

        private float fallingRate = 0.07f;
        private float nextFall = 0f;

        private void Awake()
        {
            DisablePhysics();
            transform = GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
            MoveDown();
        }

        public void RotateLeft()
        {
            if (canTurn)
                transform.Rotate(Vector3.forward, 90);
        }

        public void MoveLeft()
        {
            transform.Translate(leftVector, Space.World);
        }

        public void MoveRight()
        {
            transform.Translate(rightVector, Space.World);
        }

        public void MoveDown()
        {
            if (!hasPhysics && Time.time > nextFall)
            {
                //If the block fall, reset the nextfall time to a new point in the future.
                nextFall = Time.time + fallingRate;

                transform.Translate(downVector, Space.World);
            }
        }

        public void DisablePhysics()
        {
            //rigidbody.bodyType = RigidbodyType2D.Kinematic;
            rigidbody.gravityScale = 0;
            hasPhysics = false;
        }

        public void EnabledPhysics()
        {
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
            rigidbody.gravityScale = 0.2f;
            hasPhysics = true;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!hasPhysics)
            {
                EnabledPhysics();

                // Block Collided
                OnBlockCollided?.Trigger();
            }
        }
    }
}