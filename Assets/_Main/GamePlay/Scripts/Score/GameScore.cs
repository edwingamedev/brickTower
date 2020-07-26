using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    public class GameScore : MonoBehaviour
    {
        public GameContainer gameContainer;
        public ScriptableEvent noMoveLivesEvent;
        public IntScriptableEvent getCurrentLives;

        private int currentLives;

        public void GetCurrentLives()
        {
            getCurrentLives.Trigger(currentLives);
        }

        public void ResetLives()
        {
            for (int i = currentLives; i < gameContainer.numOfLives; i++)
            {
                AddLife();
            }
        }

        public void AddLife()
        {
            currentLives++;
        }

        public void RemoveLife()
        {
            currentLives--;

            if (currentLives <= 0)
                NoMoreLives();            
        }

        public void NoMoreLives()
        {
            noMoveLivesEvent.Trigger();
        }

    }
}