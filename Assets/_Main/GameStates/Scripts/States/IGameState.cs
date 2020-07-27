using UnityEngine;

namespace EdwinGameDev
{
    public interface IGameState
    {
        GameStateType StateType { get; set; }
        void Execute(StateCommandType commandType);
    }
}