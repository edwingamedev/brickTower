using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    [CreateAssetMenu(menuName = "Edwin Game Dev/ScreenCommands")]
    public class ScreenCommands : ScriptableObject
    {
        public List<StateCommand> stateCommands;
    }
}