using System;
using UnityEngine;

namespace EdwinGameDev
{
    [CreateAssetMenu(menuName = "Edwin Game Dev/States/StateCommand ScriptableEvent")]
    public class StateCommandScriptableEvent : ScriptableObject
    {
        public event Action<StateCommandType> OnTriggered;
        public void Trigger(StateCommandType args)
        {
            OnTriggered?.Invoke(args);
        }
    }
}