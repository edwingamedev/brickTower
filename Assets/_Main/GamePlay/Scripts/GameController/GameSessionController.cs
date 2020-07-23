using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace EdwinGameDev
{
    public class GameSessionController : MonoBehaviour
    {
        private GameStateType currentGameStatus = GameStateType.Intro;
        private GameStateType previousGameStatus = GameStateType.Intro;

        private Dictionary<GameStateType, IGameState> gameStates = new Dictionary<GameStateType, IGameState>();
        public GameScreens gameScreens;
        public StringScriptableEvent gameSessionEvent;

        private void Start()
        {
            gameSessionEvent.OnTriggered += Execute;
            Init();
        }

        public void Init()
        {
            gameStates.Clear();

            // Fill Game states
            GameStateFactory gameStateFactory = new GameStateFactory();

            foreach ((GameScreenSettings settings, IGameState gamestate) in from GameScreenSettings screen in gameScreens.screens
                                                                            let gamestate = gameStateFactory.MakeGameState(screen)
                                                                            select (screen, gamestate))
            {
                gameStates.Add(settings.gameStateType, gamestate);
            }

            // Sets to intro game state
            ChangeGameState(GameStateType.Intro);
            Execute("init");
        }

        public void Execute(string eventName)
        {
            Debug.Log($"{currentGameStatus} Screen execute: {eventName}");

            // Use the loop of the current game state
            gameStates[currentGameStatus].Execute(eventName.ToLower());
        }

        public void StartGame(string eventName)
        {
            ChangeGameState(GameStateType.Playing);
            Execute(eventName);
        }

        public void PauseGame(string eventName)
        {
            ChangeGameState(GameStateType.Paused);
            Execute(eventName);
        }

        public void GameOver(string eventName)
        {
            ChangeGameState(GameStateType.GameOver);
            Execute(eventName);
        }

        public void ChangeGameState(GameStateType gameState)
        {
            previousGameStatus = currentGameStatus;
            currentGameStatus = gameState;
        }

        private void OnDestroy()
        {
            gameSessionEvent.OnTriggered -= Execute;
        }

    }
}