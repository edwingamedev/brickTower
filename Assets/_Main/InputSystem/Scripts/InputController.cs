using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            ValidateInput();
        }

        private void ValidateInput()
        {
            InputType inputType = inputProcessor.CheckInputByType();

            if(inputType!= InputType.NoInput)
            {
                InputMapper inputMapper = inputMap.eventMappers.FirstOrDefault(t => t.inputType == inputType);

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
            if (inputProcessor != null && inputMap.inputTypeProcessor == previousInputProcessor)
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
            }

            previousInputProcessor = inputMap.inputTypeProcessor;
        }

    }
}