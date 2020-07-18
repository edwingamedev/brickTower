using UnityEngine;

namespace EdwinGameDev
{
    public class PlayingGameState : IGameState
    {
        public GameStateType StateType { get; set; }

        public PlayingGameState()
        {
            StateType = GameStateType.Playing;
        }

        public void Loop()
        {
            
        }
    }
}