using UnityEngine;
using System.Collections.Generic;
using System;

namespace EdwinGameDev
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