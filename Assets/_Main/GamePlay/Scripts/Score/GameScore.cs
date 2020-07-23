using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    public class GameScore : MonoBehaviour
    {
        public int lives;
        private int currentLives;
        public ScriptableEvent noMoveLives;

        public void ResetLives()
        {
            for (int i = currentLives; i < lives; i++)
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
            noMoveLives.Trigger();
        }

    }
}