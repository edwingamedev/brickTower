using EdwinGameDev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour
{
    public Image[] life;
    public StringScriptableEvent scriptableEvent;

    private void Start()
    {
        scriptableEvent.OnTriggered += DisplayLives;
    }

    private void OnDestroy()
    {
        scriptableEvent.OnTriggered -= DisplayLives;
    }

    public void DisplayLives(string lives)
    {
        int numOfLives = int.Parse(lives);

        for (int i = 0; i < life.Length; i++)
        {
            life[i].enabled = false;
        }

        for (int i = 0; i < numOfLives; i++)
        {
            life[i
                
                ].enabled = true;
        }
    }
}
