using System;
using System.Linq;
using UnityEngine;

namespace EdwinGameDev
{
    public class PausedGameState : AGameState
    {
        public PausedGameState(GameScreenSettings screenSettings)
        {
            StateType = GameStateType.Paused;
            this.screenSettings = screenSettings;
        }
        public override void Execute(StateCommandType stateCommandType)
        {
            {
                switch (stateCommandType)
                {
                    case StateCommandType.ResumeScene:
                        ChangeScene(stateCommandType);
                        break;
                    case StateCommandType.OpenScene:
                        StartScene(stateCommandType);
                        break;
                    case StateCommandType.ChangeScene:
                        ChangeScene(stateCommandType);
                        break;
                    case StateCommandType.StartGame:
                        ChangeScene(stateCommandType);
                        break;
                    case StateCommandType.PauseGame:
                        StartScene(stateCommandType);
                        break;
                    case StateCommandType.GoToMenu:
                        ChangeScene(stateCommandType);
                        break;
                }
            }
        }
    }
}