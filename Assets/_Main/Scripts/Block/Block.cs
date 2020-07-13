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

        private bool hasPhysics = false;

        private Vector2 leftVector = new Vector2(1, 0);
        private Vector2 rightVector = new Vector2(1, 0);

        private void Awake()
        {
            transform = GetComponent<Transform>();
        }

        public void RotateLeft()
        {
            transform.Rotate(Vector3.forward, 90);
        }

        public void MoveLeft()
        {
            transform.Translate(leftVector);
        }

        public void MoveRight()
        {
            transform.Translate(rightVector);
        }

        public void MoveDown()
        {

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!hasPhysics)
            {
                rigidbody.bodyType = RigidbodyType2D.Dynamic;
                hasPhysics = true;
            }
        }
    }
}