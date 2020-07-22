using System.Linq;
using UnityEngine;

namespace EdwinGameDev
{
    public class GameOverGameState : IGameState
    {
        public GameStateType StateType { get; set; }
        private GameObject screenPrefab;
        private GameScreenSettings screenSettings;

        public GameOverGameState(GameScreenSettings screenSettings)
        {
            StateType = GameStateType.GameOver;
            this.screenSettings = screenSettings;
        }

        public void Execute(string actionName)
        {
            EventMapper eventMapper = screenSettings.eventMap.eventMappers.FirstOrDefault(t => t.eventName.ToLower() == actionName);

            if (string.IsNullOrEmpty(eventMapper.eventName))
            {
                Debug.Log($"IntroGameState {actionName}");
                return;
            }

            // Menu
            if (eventMapper.eventName.ToLower() == "gotomenu")
            {
                ChangeScene(eventMapper);
            }

            // Play
            if (eventMapper.eventName.ToLower() == "play")
            {
                ChangeScene(eventMapper);
            }

            // gameover
            if (eventMapper.eventName.ToLower() == "gameover")
            {
                GameOver(eventMapper);
            }
        }

        private void ChangeScene(EventMapper eventMapper)
        {
            // Disable screen
            screenPrefab.SetActive(false);

            eventMapper.scriptableEvent?.Trigger();
        }

        private void GameOver(EventMapper eventMapper)
        {
            if (screenPrefab == null)
                screenPrefab = GameObject.Instantiate(screenSettings.screenPrefab);
            else
                screenPrefab.SetActive(true);

            eventMapper.scriptableEvent?.Trigger();
        }
    }
}