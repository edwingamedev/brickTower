using System;
using UnityEngine;

namespace EdwinGameDev
{
    [Serializable]
    public struct GameScreenSettings
    {
        public GameStateType gameStateType;
        public GameObject screenPrefab;
        public EventMap eventMap;
    }
}