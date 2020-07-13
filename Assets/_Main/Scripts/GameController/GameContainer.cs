using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Edwin Game Dev/GameContainer")]
public class GameContainer : ScriptableObject
{
    public Block currentPlayingBlock;
}