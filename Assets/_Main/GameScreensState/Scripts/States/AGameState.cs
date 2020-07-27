using System.Linq;
using UnityEngine;

namespace EdwinGameDev
{
    public abstract class AGameState : IGameState
    {
        public GameStateType StateType { get; set; }
        protected GameObject screenPrefab;
        protected GameScreenSettings screenSettings;

        public abstract void Execute(StateCommandType stateCommandType);
        
        protected virtual void ChangeScene(StateCommandType stateCommandType)
        {
            // Disable screen
            screenPrefab.SetActive(false);

            screenSettings.screenCommands.stateCommands.FirstOrDefault(s => s.stateCommandType == stateCommandType).scriptableEvent?.Trigger();
        }

        protected virtual void Resume(StateCommandType stateCommandType)
        {
            // enable screen
            screenPrefab.SetActive(true);

            screenSettings.screenCommands.stateCommands.FirstOrDefault(s => s.stateCommandType == stateCommandType).scriptableEvent?.Trigger();
        }

        protected virtual void StartScene(StateCommandType stateCommandType)
        {
            if (screenPrefab == null)
                screenPrefab = GameObject.Instantiate(screenSettings.screenPrefab);
            else
                screenPrefab.SetActive(true);

            screenSettings.screenCommands.stateCommands.FirstOrDefault(s => s.stateCommandType == stateCommandType).scriptableEvent?.Trigger();
        }
    }
}