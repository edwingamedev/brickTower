using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EdwinGameDev
{
    public class GameStateFactory
    {
        private IGameState gameState;

        public GameStateFactory()
        {

        }

        public IGameState MakeGameState(GameScreenSettings screenSettings)
        {
            switch (screenSettings.gameStateType)
            {
                case GameStateType.Intro:
                    gameState = new IntroGameState(screenSettings);
                    break;
                case GameStateType.Playing:
                    gameState = new PlayingGameState(screenSettings);
                    break;
                case GameStateType.Paused:
                    gameState = new PausedGameState(screenSettings);
                    break;
                case GameStateType.GameOver:
                    gameState = new GameOverGameState(screenSettings);
                    break;
                default:
                    break;
            }

            return gameState;
        }
    }
}