using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionController : MonoBehaviour
{
    private GameStateType currentGameStatus = GameStateType.Intro;

    private Dictionary<GameStateType, IGameState> gameStates = new Dictionary<GameStateType, IGameState>();

    public void StartGame()
    {

    }

    private void Start()
    {
        
    }

    private void Update()
    {
        GameLoop();
    }

    public void ChangeGameState(GameStateType gameState)
    {
        currentGameStatus = gameState;
    }

    private void GameLoop()
    {
        // Use the loop of the current game state
        gameStates[currentGameStatus].Loop();
    }
}
