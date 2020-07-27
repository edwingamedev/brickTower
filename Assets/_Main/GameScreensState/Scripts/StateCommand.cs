using UnityEngine;
using System;

namespace EdwinGameDev
{
    [Serializable]
    public class StateCommand
    {
        public StateCommandType stateCommandType;
        public ScriptableEvent scriptableEvent;

        public StateCommand(StateCommandType stateCommandType, ScriptableEvent scriptableEvent)
        {
            this.stateCommandType = stateCommandType;
            this.scriptableEvent = scriptableEvent;
        }
    }
}