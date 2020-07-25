using UnityEngine;

namespace EdwinGameDev
{
    public class StateCommandToUnityEvent : MonoBehaviour
    {        
        public StateCommandType stateCommand;
        public StateCommandScriptableEvent action;

        public void Callback()
        {
            action.Trigger(stateCommand);
        }
    }
}