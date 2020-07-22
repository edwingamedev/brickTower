using System;
using System.Linq;
using UnityEngine;

namespace EdwinGameDev
{
    public class PausedGameState : IGameState
    {
        public GameStateType StateType { get; set; }
        private GameObject screenPrefab;
        private GameScreenSettings screenSettings;

        public PausedGameState(GameScreenSettings screenSettings)
        {
            StateType = GameStateType.Paused;
            this.screenSettings = screenSettings;
        }

        public void Execute(string actionName)
        {
            EventMapper eventMapper = screenSettings.eventMap.eventMappers.FirstOrDefault(t => t.eventName.ToLower() == actionName);

            if (string.IsNullOrEmpty(eventMapper.eventName))
                return;

            // Menu
            if (eventMapper.eventName.ToLower() == "gotomenu")
            {
                ChangeScene(eventMapper);
            }

            // pause Game
            if (eventMapper.eventName.ToLower() == "pausegame")
            {
                PauseGame(eventMapper);
            }

            // resume
            if (eventMapper.eventName.ToLower() == "resumegame")
            {
                ChangeScene(eventMapper);
            }
        }

        private void ChangeScene(EventMapper eventMapper)
        {
            // Disable screen
            screenPrefab.SetActive(false);

            eventMapper.scriptableEvent?.Trigger();
        }

        private void PauseGame(EventMapper eventMapper)
        {
            if (screenPrefab == null)
                screenPrefab = GameObject.Instantiate(screenSettings.screenPrefab);
            else
                screenPrefab.SetActive(true);

            eventMapper.scriptableEvent?.Trigger();
        }
    }
}