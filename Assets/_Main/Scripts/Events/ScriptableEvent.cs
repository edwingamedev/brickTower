using System;
using UnityEngine;

namespace EdwinGameDev
{
    public delegate void Execute();  // delegate

    [CreateAssetMenu(menuName = "Edwin Game Dev/ScriptableEvent")]
    public class ScriptableEvent : ScriptableObject
    {
        public event Action OnTriggered;
        public void Trigger()
        {
            OnTriggered?.Invoke();
        }
    }
}