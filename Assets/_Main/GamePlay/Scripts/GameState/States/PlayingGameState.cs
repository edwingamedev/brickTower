using System;
using System.Linq;
using UnityEngine;

namespace EdwinGameDev
{
    public class PlayingGameState : IGameState
    {
        public GameStateType StateType { get; set; }
        private GameObject screenPrefab;
        private GameScreenSettings screenSettings;

        public PlayingGameState(GameScreenSettings screenSettings)
        {
            StateType = GameStateType.Playing;
            this.screenSettings = screenSettings;
        }

        public void Execute(string actionName)
        {
            EventMapper eventMapper = screenSettings.eventMap.eventMappers.FirstOrDefault(t => t.eventName.ToLower() == actionName);

            if (string.IsNullOrEmpty(eventMapper.eventName))
                return;

            // Start Game
            if (eventMapper.eventName.ToLower() == "startgame")
            {
                StartGame(eventMapper);
            }

            // Start Game
            if (eventMapper.eventName.ToLower() == "resumegame")
            {
                ResumeGame(eventMapper);
            }

            // Pause Game
            if (eventMapper.eventName.ToLower() == "pausegame")
            {
                PauseGame(eventMapper);
            }
        }

        private void ResumeGame(EventMapper eventMapper)
        {
            // Disable screen
            screenPrefab.SetActive(true);

            eventMapper.scriptableEvent?.Trigger();
        }

        private void PauseGame(EventMapper eventMapper)
        {
            // Disable screen
            screenPrefab.SetActive(false);

            eventMapper.scriptableEvent?.Trigger();
        }

        private void StartGame(EventMapper eventMapper)
        {
            // Instantiate screen
            if (screenPrefab == null)
                screenPrefab = GameObject.Instantiate(screenSettings.screenPrefab);
            else
                screenPrefab.SetActive(true);

            eventMapper.scriptableEvent?.Trigger();
        }
    }
}