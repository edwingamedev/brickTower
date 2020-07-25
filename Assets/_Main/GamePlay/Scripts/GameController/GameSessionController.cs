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
        public StateCommandScriptableEvent gameSessionEvent;
        public GameContainer gameContainer;

        public ScriptableEvent OnStartGame;
        public ScriptableEvent OnPauseGame;
        public ScriptableEvent OnGameOver;
        public ScriptableEvent OnResumeGame;
        public ScriptableEvent OnGoToMenu;

        private void Start()
        {
            gameSessionEvent.OnTriggered += Execute;

            OnStartGame.OnTriggered += StartGame;
            OnPauseGame.OnTriggered += PauseGame;
            OnGameOver.OnTriggered += GameOver;
            OnResumeGame.OnTriggered += ResumeGame;
            OnGoToMenu.OnTriggered += GameIntro;

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
            GameIntro();
        }

        public void Execute(StateCommandType commandType)
        {
            Debug.Log($"{currentGameStatus} Screen execute: {commandType}");

            // Use the loop of the current game state
            gameStates[currentGameStatus].Execute(commandType);
        }

        public void GameIntro()
        {
            ChangeGameState(GameStateType.Intro);
            Execute(StateCommandType.OpenScene);
        }

        public void StartGame()
        {
            ChangeGameState(GameStateType.Playing);
            Execute(StateCommandType.OpenScene);

            // Unpause
            gameContainer.SetPause(false);
        }

        public void ResumeGame()
        {
            ChangeGameState(GameStateType.Playing);
            Execute(StateCommandType.ResumeScene);

            // Unpause
            gameContainer.SetPause(false);
        }

        public void PauseGame()
        {
            ChangeGameState(GameStateType.Paused);
            Execute(StateCommandType.OpenScene);

            // Pause
            gameContainer.SetPause(true);
        }

        public void GameOver()
        {
            ChangeGameState(GameStateType.GameOver);
            Execute(StateCommandType.OpenScene);

            // Pause
            gameContainer.SetPause(true);
        }

        public void ChangeGameState(GameStateType gameState)
        {
            previousGameStatus = currentGameStatus;
            currentGameStatus = gameState;
        }

        private void OnDestroy()
        {
            gameSessionEvent.OnTriggered -= Execute;
            OnStartGame.OnTriggered -= StartGame;
            OnPauseGame.OnTriggered -= PauseGame;
            OnGameOver.OnTriggered -= GameOver;
            OnResumeGame.OnTriggered -= ResumeGame;
            OnGoToMenu.OnTriggered -= GameIntro;
        }

    }
}