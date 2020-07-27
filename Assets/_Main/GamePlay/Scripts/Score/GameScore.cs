using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev
{
    public class GameScore : MonoBehaviour
    {
        public GameContainer gameContainer;

        public ScriptableEvent noMoreLivesEvent;
        public ScriptableEvent gameWonEvent;

        public IntScriptableEvent getCurrentLives;
        public IntScriptableEvent getCurrentScore;

        private int currentScore;
        private int currentLives;

        public void SendCurrentLives()
        {
            getCurrentLives.Trigger(currentLives);
        }

        public void SendCurrentScore()
        {
            getCurrentScore.Trigger(currentScore);
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


        public void ResetScore()
        {
            currentScore = 0;

            // Send event
            SendCurrentScore();
        }

        public void IncreaseScore()
        {
            currentScore += 10;

            // Send event
            SendCurrentScore();
        }

        public void DecreaseScore()
        {
            if (currentScore > 0)
            {
                currentScore -= 5;

                // Send event
                SendCurrentScore();
            }
        }

        public void CheckWinCondition()
        {
            // Won
            if (gameContainer.towerHeight >= gameContainer.heightToWin)
                gameWonEvent.Trigger();
        }

        public void NoMoreLives()
        {
            noMoreLivesEvent.Trigger();
        }

    }
}