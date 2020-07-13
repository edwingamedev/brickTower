using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.PlayerLoop;
using System;

namespace EdwinGameDev.Events
{
    [CreateAssetMenu(menuName = "Edwin Game Dev/EventMapping")]
    public class EventMapping : ScriptableObject
    {
        [Serializable]
        public struct InputCommand
        {
            public KeyCode keyCode;
            public InputEvent command;
        }

        public List<InputCommand> inputEvents = new List<InputCommand>();
        private void Update()
        {

        }
    }
}