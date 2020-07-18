using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    public class InputController : IInputController
    {
        public GameContainer gameContainer;
        private GameSessionController gameSessionController;

        public InputController(GameContainer gameContainer, GameSessionController gameSessionController)
        {
            this.gameContainer = gameContainer;
            this.gameSessionController = gameSessionController;
        }

        private void RotateBlock()
        {
            
        }

        private void MoveBlockLeft()
        {
            
        }

        private void MoveBlockRight()
        {
           
        }

        private void MoveBlockDown()
        {
           
        }

        public void ProcessInput(InputType input)
        {
            switch (input)
            {
                case InputType.RotateBlock:
                    RotateBlock();
                    break;

                case InputType.MoveBlockLeft:
                    MoveBlockLeft();
                    break;

                case InputType.MoveBlockRight:
                    MoveBlockRight();
                    break;

                case InputType.MoveBlockDown:
                    MoveBlockDown();
                    break;

                default:
                    break;
            }
        }
    }
}