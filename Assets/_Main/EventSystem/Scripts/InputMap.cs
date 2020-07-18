using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    [Serializable]
    public struct InputMapper
    {
        public InputType inputType;
        public ScriptableEvent scriptableEvent;
    }

    public enum InputTypeProcessor
    {
        Touch,
        Keyboard,
        Mouse
    }

    [CreateAssetMenu(menuName = "Edwin Game Dev/InputMap")]
    public class InputMap : ScriptableObject
    {
        public InputTypeProcessor inputTypeProcessor;
        public List<InputMapper> eventMappers;        
    }
}
