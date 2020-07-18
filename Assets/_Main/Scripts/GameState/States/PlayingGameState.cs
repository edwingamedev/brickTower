using UnityEngine;

namespace EdwinGameDev
{
    public class PlayingGameState : AGameState
    {
        public override GameStateType StateType { get; set; }

        public PlayingGameState()
        {
            StateType = GameStateType.Playing;
        }

        public override void Loop()
        {
            
        }
    }
}