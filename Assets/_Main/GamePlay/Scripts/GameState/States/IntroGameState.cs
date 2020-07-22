using System;
using UnityEngine;
using System.Linq;

namespace EdwinGameDev
{
    public class IntroGameState : IGameState
    {
        public GameStateType StateType { get; set; }
        private GameObject screenPrefab;
        private GameScreenSettings screenSettings;

        public IntroGameState(GameScreenSettings screenSettings)
        {
            StateType = GameStateType.Intro;
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

            // Init
            if (eventMapper.eventName.ToLower() == "init")
            {
                Init(eventMapper);
            }

            // Play
            if (eventMapper.eventName.ToLower() == "play")
            {
                Play(eventMapper);
            }
        }

        private void Play(EventMapper eventMapper)
        {
            // Disable screen
            screenPrefab.SetActive(false);

            eventMapper.scriptableEvent?.Trigger();
        }

        private void Init(EventMapper eventMapper)
        {
            if (screenPrefab == null)
                screenPrefab = GameObject.Instantiate(screenSettings.screenPrefab);
            else
                screenPrefab.SetActive(true);

            eventMapper.scriptableEvent?.Trigger();
        }
    }
}