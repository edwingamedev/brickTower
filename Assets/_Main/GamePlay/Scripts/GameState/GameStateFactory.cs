using System;
using System.Collections.Generic;
using System.Linq;

namespace EdwinGameDev
{
    public class GameStateFactory
    {
        private IGameState gameState;

        public GameStateFactory()
        {

        }

        public List<IGameState> MakeAllStates()
        {
            List<IGameState> s = new List<IGameState>();

            foreach (GameStateType t in Enum.GetValues(typeof(GameStateType)))
            {
                s.Add(MakeGameState(t));
            }

            return s;
        }

        public IGameState MakeGameState(GameStateType stateType)
        {
            switch (stateType)
            {
                case GameStateType.Intro:
                    gameState = new IntroGameState();
                    break;
                case GameStateType.Playing:
                    gameState = new PlayingGameState();
                    break;
                case GameStateType.Paused:
                    gameState = new PausedGameState();
                    break;
                case GameStateType.GameOver:
                    gameState = new GameOverGameState();
                    break;
                default:
                    break;
            }

            return gameState;
        }
    }
}