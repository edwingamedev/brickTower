using System;
using System.Linq;
using UnityEngine;

namespace EdwinGameDev
{
    public class PlayingGameState : AGameState
    {
        public PlayingGameState(GameScreenSettings screenSettings)
        {
            StateType = GameStateType.Playing;
            this.screenSettings = screenSettings;
        }

        public override void Execute(StateCommandType stateCommandType)
        {
            {
                switch (stateCommandType)
                {
                    case StateCommandType.OpenScene:
                        StartScene(stateCommandType);
                        break;
                    case StateCommandType.ResumeScene:
                        Resume(stateCommandType);
                        break;
                    case StateCommandType.ChangeScene:
                        ChangeScene(stateCommandType);
                        break;
                    case StateCommandType.PauseGame:
                        ChangeScene(stateCommandType);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}