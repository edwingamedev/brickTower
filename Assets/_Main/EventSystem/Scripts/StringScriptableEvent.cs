using System;
using UnityEngine;

namespace EdwinGameDev
{
    [CreateAssetMenu(menuName = "Edwin Game Dev/String ScriptableEvent")]
    public class StringScriptableEvent : ScriptableObject
    {
        public event Action<string> OnTriggered;
        public void Trigger(string args)
        {
            OnTriggered?.Invoke(args);
        }
    }
}