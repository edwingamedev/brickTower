using UnityEngine;

namespace EdwinGameDev
{
    public class EventMapToUnityEvent : MonoBehaviour
    {
        public EventMap eventMap;
                
        [HideInInspector]
        public string eventName; 

        public StringScriptableEvent action;

        public void Callback()
        {
            action.Trigger(eventName);
        }
    }
}
