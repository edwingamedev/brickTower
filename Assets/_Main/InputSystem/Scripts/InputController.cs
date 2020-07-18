using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    public class InputController : MonoBehaviour
    {
        public InputMap inputMap;
        private IInputProcessor inputProcessor;
        private InputTypeProcessor previousInputProcessor;

        private void Update()
        {
            UpdateInputMap();
        }
        
        private void UpdateInputMap()
        {            
            CheckInputProcessorType();

            foreach (InputMapper inputMapper in inputMap.eventMappers)
            {
                InputType inputType = inputMapper.inputType;

                bool execute;

                switch (inputType)
                {
                    //Execute actions
                    case InputType.Left:
                        execute = inputProcessor.Left();
                        break;
                    case InputType.Right:
                        execute = inputProcessor.Right();
                        break;
                    case InputType.Up:
                        execute = inputProcessor.Up();
                        break;
                    case InputType.Down:
                        execute = inputProcessor.Down();
                        break;
                    case InputType.Release:
                        execute = inputProcessor.Release();
                        break;
                    case InputType.Click:
                        execute = inputProcessor.Click();
                        break;
                    case InputType.Hold:
                        execute = inputProcessor.Hold();
                        break;                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (!execute) continue;

                ScriptableEvent action = inputMapper.scriptableEvent;

                //Execute the action
                if (action)
                {
                    action.Trigger();
                }
            }
        }

        /// <summary>
        /// Defines which input processor to use
        /// </summary>
        private void CheckInputProcessorType()
        {
            if (inputMap.inputTypeProcessor == previousInputProcessor)
                return;

            switch (inputMap.inputTypeProcessor)
            {
                default:
                case InputTypeProcessor.Keyboard:
                    inputProcessor = new KeyboardProcessor();
                    break;
                case InputTypeProcessor.Touch:
                    inputProcessor = new TouchProcessor();
                    break;
                case InputTypeProcessor.Mouse:
                    inputProcessor = new MouseProcessor();
                    break;
            }

            previousInputProcessor = inputMap.inputTypeProcessor;
        }

    }
}