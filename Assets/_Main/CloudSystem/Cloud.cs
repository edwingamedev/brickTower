using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    public class Cloud : MonoBehaviour
    {
        private float currentMoveTick;
        public GameData gameData;
        public GameGrid gameGrid;
        public Vector2 direction;
        public SpriteRenderer spriteRenderer;
        bool canmove = false;

        private void Update()
        {
            Move();
        }

        public void SetDirection(bool moveRight)
        {
            direction = moveRight ? Vector2.right / 5 : Vector2.left / 5;
        }

        public void InitCloud(Sprite sprite, Color color, bool moveRight)
        {
            SetColor(color);
            SetSprite(sprite);
            SetDirection(moveRight);

            canmove = true;
        }

        public void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }

        public void SetSprite(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }


        private void Move()
        {
            if (!canmove)
                return;

            if (Time.time > currentMoveTick)
            {
                gameObject.transform.position = gameObject.transform.position + new Vector3(direction.x, direction.y);
                currentMoveTick = Time.time + .25f;

                // Left
                if (gameObject.transform.position.x < gameGrid.gridMinX * 2)
                {
                    Destroy(gameObject);
                }

                // Right
                if (gameObject.transform.position.x > gameGrid.gridMaxX * 2)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}