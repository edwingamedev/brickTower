using UnityEngine;
using UnityEditor;

namespace EdwinGameDev
{
    [CreateAssetMenu(menuName = "Edwin Game Dev/GameContainer")]
    public class GameContainer : ScriptableObject
    {
        public Block currentPlayingBlock;
    }
}