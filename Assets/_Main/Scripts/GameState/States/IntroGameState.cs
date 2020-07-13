public class IntroGameState : AGameState
{
    public override GameStateType StateType { get ; set; }
    public override IInputController InputController { get; set; }

    public IntroGameState(IInputController IC)
    {
        StateType = GameStateType.Playing;
        InputController = IC;
    }

    public override void Loop()
    {
        
    }
}