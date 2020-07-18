using System;
using UnityEngine;

namespace EdwinGameDev
{
    public class TouchDetector
    {
        private Vector2 fingerUp;
        private Vector2 fingerDown;
        private float swipeThreshold = 20f;

        public TouchDetector()
        {
           
        }

        public bool DetectTouch(InputType touchType, bool detectSwipeOnlyAfterRelease)
        {
            // Touch Detector
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    fingerUp = touch.position;
                    fingerDown = touch.position;
                }

                //Detects Swipe while finger is still moving
                if (touch.phase == TouchPhase.Moved)
                {
                    if (!detectSwipeOnlyAfterRelease)
                    {
                        fingerDown = touch.position;
                        return CheckSwipe(touchType);
                    }
                }

                //Detects swipe after finger is released
                if (touch.phase == TouchPhase.Ended)
                {
                    fingerDown = touch.position;
                    return CheckSwipe(touchType);
                }
            }

            return false;
        }


        private bool CheckSwipe(InputType touchType)
        {
            //Check if Vertical swipe
            if (verticalMove() > swipeThreshold && verticalMove() > horizontalValMove())
            {
                if (fingerDown.y - fingerUp.y > 0 && touchType == InputType.Up)// Swipe Up
                {
                    return true;
                }
                else if (fingerDown.y - fingerUp.y < 0 && touchType == InputType.Down)// Swipe Down
                {
                    return true;
                }

                fingerUp = fingerDown;

                // No Movement
                return false;
            } 
            // Check if Horizontal swipe            
            else if (horizontalValMove() > swipeThreshold && horizontalValMove() > verticalMove())
            {
                if (fingerDown.x - fingerUp.x > 0 && touchType == InputType.Right)// Swipe Right
                {
                    return true;
                }
                else if (fingerDown.x - fingerUp.x < 0 && touchType == InputType.Left)// Swipe Left
                {
                    return true;
                }

                fingerUp = fingerDown;

                // No Movement
                return false;
            }
            // No Movement
            else
            {
                return false;
            }
        }

        float verticalMove()
        {
            return Mathf.Abs(fingerDown.y - fingerUp.y);
        }

        float horizontalValMove()
        {
            return Mathf.Abs(fingerDown.x - fingerUp.x);
        }
    }
}