namespace EdwinGameDev
{
    public abstract class AGameState : IGameState
    {
        public abstract GameStateType StateType { get; set; }
        public abstract void Loop();
    }
}