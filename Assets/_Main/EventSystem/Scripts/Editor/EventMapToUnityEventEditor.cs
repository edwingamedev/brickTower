using System.Linq;
using System;
using UnityEditor;

namespace EdwinGameDev
{
    [CustomEditor(typeof(EventMapToUnityEvent))]
    public class EventMapToUnityEventEditor : Editor
    {
        private string[] choices = new[] { " " };
        private int choiceIndex = 0;

        public override void OnInspectorGUI()
        {
            // Draw the default inspector
            DrawDefaultInspector();

            EventMapToUnityEvent eventMapToUnityEvent = target as EventMapToUnityEvent;

            if (eventMapToUnityEvent.eventMap != null && eventMapToUnityEvent.eventMap.eventMappers.Any())
            {
                choices = eventMapToUnityEvent.eventMap.eventMappers.Select(em => em.eventName).ToArray();
            }

            // Set the choice index to the previously selected index
            choiceIndex = Array.IndexOf(choices, eventMapToUnityEvent.eventName);

            choiceIndex = EditorGUILayout.Popup(choiceIndex, choices);

            // Update the selected choice in the underlying object
            eventMapToUnityEvent.eventName = choices[choiceIndex];

            // Save the changes back to the object
            EditorUtility.SetDirty(target);
        }
    }
}