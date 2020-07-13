using UnityEngine;

namespace EdwinGameDev.Events
{
    public delegate void Execute();  // delegate

    [CreateAssetMenu(menuName = "Edwin Game Dev/InputEvent")]
    public class InputEvent : ScriptableObject
    {
        private Execute execute;

        public void Assign(Execute action)
        {
            execute += action;
        }

        public void Withhold(Execute action)
        {
            execute -= action;
        }

        public void Execute()
        {
            execute?.Invoke();
        }

    }
}