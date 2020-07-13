public abstract class AGameState : IGameState
{
    public abstract IInputController InputController { get; set; }
    public abstract GameStateType StateType { get ; set; }
    public abstract void Loop();
}