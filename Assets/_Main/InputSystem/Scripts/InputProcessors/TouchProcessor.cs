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
            return touchDetector.DetectTouch(InputType.Left,false);
        }

        public bool Right()
        {
            return touchDetector.DetectTouch(InputType.Right, false);
        }

        public bool Up()
        {
            return touchDetector.DetectTouch(InputType.Up, false);
        }

        public bool Down()
        {
            return touchDetector.DetectTouch(InputType.Down, false);
        }

        public bool Click()
        {
            throw new System.NotImplementedException();
        }

        public bool Release()
        {
            throw new System.NotImplementedException();
        }

        public bool Hold()
        {
            throw new System.NotImplementedException();
        }
    }
}