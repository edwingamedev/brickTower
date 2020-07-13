public interface IGameState
{
    GameStateType StateType { get; set; } 
    void Loop();
}