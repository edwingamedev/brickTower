using System;
using UnityEngine;

namespace EdwinGameDev
{
    [CreateAssetMenu(menuName = "Edwin Game Dev/Int ScriptableEvent")]
    public class IntScriptableEvent : ScriptableObject
    {
        public event Action<int> OnTriggered;
        public void Trigger(int args)
        {
            OnTriggered?.Invoke(args);
        }
    }
}