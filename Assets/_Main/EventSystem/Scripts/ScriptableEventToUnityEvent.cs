using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EdwinGameDev
{
    public class ScriptableEventToUnityEvent : MonoBehaviour
    {
        public ScriptableEvent scriptableEvent;
        public UnityEvent Action;
        private void OnEnable()
        {
            if (scriptableEvent != null)
                scriptableEvent.OnTriggered += Callback;
        }

        private void OnDisable()
        {
            if (scriptableEvent != null)
                scriptableEvent.OnTriggered -= Callback;
        }

        private void Callback()
        {
            Action?.Invoke();
        }
    }
}