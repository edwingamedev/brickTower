using System;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    [CreateAssetMenu(menuName = "Edwin Game Dev/Events/EventMap")]
    public class EventMap : ScriptableObject
    {
        public List<EventMapper> eventMappers;
    }
}