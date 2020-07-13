using UnityEngine;

namespace EdwinGameDev
{
    public class PlayingGameState : AGameState
    {
        public override GameStateType StateType { get; set; }
        public override IInputController InputController { get; set; }

        public PlayingGameState(IInputController IC)
        {
            StateType = GameStateType.Playing;
            InputController = IC;
        }

        public override void Loop()
        {
            if (Input.GetKeyUp(KeyCode.Space))
                RotateBlock();
        }

        private void RotateBlock()
        {
            InputController.ProcessInput(InputType.RotateBlock);
        }
    }
}