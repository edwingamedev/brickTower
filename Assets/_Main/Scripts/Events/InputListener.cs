using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EdwinGameDev
{
    public class InputListener : MonoBehaviour
    {
        public UnityEvent command;
        public InputEvent inputEvent;

        private void OnEnable()
        {
            inputEvent.Assign(command.Invoke);
        }

        private void OnDisable()
        {
            inputEvent.Withhold(command.Invoke);
        }

    }
}