using System;
using UnityEngine;
using System.Linq;

namespace EdwinGameDev
{
    public class IntroGameState : AGameState
    {
        public IntroGameState(GameScreenSettings screenSettings)
        {
            StateType = GameStateType.Intro;
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
                    case StateCommandType.StartGame:
                        ChangeScene(stateCommandType);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}