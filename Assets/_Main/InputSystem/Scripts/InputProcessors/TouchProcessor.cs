using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    public class TouchProcessor : IInputProcessor
    {
        private TouchDetector touchDetector;

        public TouchProcessor()
        {
            touchDetector = new TouchDetector();
        }

        public bool Left()
        {
            return false;
        }

        public bool Right()
        {
            return false;
        }

        public bool Up()
        {
            return false;
        }

        public bool Down()
        {
            return false;
        }

        public bool Click()
        {
            return false;
        }

        public bool Release()
        {
            return false;// touchDetector.DetectTouch(InputType.Release, false);
        }

        public bool Hold()
        {
            return false;
        }

        public InputType CheckInputByType()
        {
            return touchDetector.DetectTouch();
        }
    }
}