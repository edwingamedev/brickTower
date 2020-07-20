using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    public class GameSessionController : MonoBehaviour
    {
        private GameStateType currentGameStatus = GameStateType.Intro;

        [SerializeField]
        private Dictionary<GameStateType, IGameState> gameStates = new Dictionary<GameStateType, IGameState>();

        public GameGrid gameGrid;
        public Transform grid;

        public void StartGame()
        {
            gameStates.Clear();

            GameStateFactory gameStateFactory = new GameStateFactory();

            List<IGameState> LGS = gameStateFactory.MakeAllStates();

            foreach (IGameState item in LGS)
            {
                gameStates.Add(item.StateType, item);
            }

            gameGrid.CreateGrid(grid);
        }

        private void Start()
        {
            StartGame();
        }

        private void Update()
        {
           // GameLoop();
        }

        public void ChangeGameState(GameStateType gameState)
        {
            currentGameStatus = gameState;
        }

        private void GameLoop()
        {
            // Use the loop of the current game state
            gameStates[currentGameStatus].Loop();
        }
    }
}