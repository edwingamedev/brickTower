using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    [CreateAssetMenu(menuName = "Edwin Game Dev/States/GameScreens")]
    public class GameScreens : ScriptableObject
    {        
        public List<GameScreenSettings> screens = new List<GameScreenSettings>();        
    }
}