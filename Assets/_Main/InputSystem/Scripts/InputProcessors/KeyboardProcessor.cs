using UnityEngine;

namespace EdwinGameDev
{
    public class KeyboardProcessor : IInputProcessor
    {
        public bool Up()
        {
            return Input.GetButtonUp("Vertical") && Input.GetAxis("Vertical") > 0;
        }

        public bool Down()
        {
            return Input.GetButton("Vertical") && Input.GetAxis("Vertical") < 0;
        }

        public bool Left()
        {
            return Input.GetButtonUp("Horizontal") && Input.GetAxis("Horizontal") < 0;
        }

        public bool Right()
        {
            return Input.GetButtonUp("Horizontal") && Input.GetAxis("Horizontal") > 0;
        }

        public bool Click()
        {
            return Input.GetButtonDown("Jump");
        }

        public bool Release()
        {
            return Input.GetButtonUp("Jump");
        }

        public bool Hold()
        {
            return Input.GetButton("Jump");
        }

        public InputType CheckInputByType()
        {
            if (Hold()) 
                return InputType.Hold;

            if (Release())
                return InputType.Release;

            if (Click())
                return InputType.Click;

            if (Up())
                return InputType.Up;

            if (Down())
                return InputType.Down;

            if (Right())
                return InputType.Right;

            if (Left())
                return InputType.Left;


            return InputType.NoInput;
        }
    }
}