using EdwinGameDev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour
{
    public GameObject lifePrefab;
    public Transform lifeContainer;
    private Queue<GameObject> lives = new Queue<GameObject>();
    public ScriptableEvent requestNumOfLives;
    public IntScriptableEvent receiveNumOfLives;

    private void OnEnable()
    {
        // Assign callback
        receiveNumOfLives.OnTriggered += CheckNumOfLives;

        // Request the current lives
        requestNumOfLives.Trigger();
    }

    private void OnDisable()
    {
        // Assign callback
        receiveNumOfLives.OnTriggered -= CheckNumOfLives;
    }

    public void CheckNumOfLives(int numOfLives)
    {
        int livesToAdd = numOfLives - lives.Count;

        for (int i = 0; i < livesToAdd; i++)
        {
            AddLife();
        }
    }

    public void AddLife()
    {
        lives.Enqueue(Instantiate(lifePrefab, lifeContainer));
    }

    public void RemoveLife()
    {
        if (lives.Count > 0)
            Destroy(lives.Dequeue());
    }
}
