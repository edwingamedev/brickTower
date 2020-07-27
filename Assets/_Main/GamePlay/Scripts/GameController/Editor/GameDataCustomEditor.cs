using UnityEditor;
using UnityEngine;

namespace EdwinGameDev
{
    [CustomEditor(typeof(GameData))]
    public class GameDataCustomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            GameData gameData = (GameData)target;

            // Lives
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Number of Lives");
            gameData.numOfLives = EditorGUILayout.IntSlider(gameData.numOfLives, 1, 10);
            EditorGUILayout.EndHorizontal();

            // Height
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Tower Height to Win the game");
            gameData.heightToWin = EditorGUILayout.IntSlider(gameData.heightToWin, 5, 200);
            EditorGUILayout.EndHorizontal();

            // Movement
            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label("Block Movement");
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Horizontal (units)");
            gameData.blockMovement.horizontal = EditorGUILayout.Slider(gameData.blockMovement.horizontal, .25f, 2f);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Vertical (units)");
            gameData.blockMovement.vertical = EditorGUILayout.Slider(gameData.blockMovement.vertical, .25f, 2f);
            EditorGUILayout.EndHorizontal();

            // Drop Rate
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Drop Rate (seconds)");
            gameData.blockDropRate = EditorGUILayout.Slider(gameData.blockDropRate, 0.1f, 1f);
            EditorGUILayout.EndHorizontal();

        }
    }
}