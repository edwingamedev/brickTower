namespace EdwinGameDev
{
    public class PausedGameState : AGameState
    {
        public override GameStateType StateType { get; set; }
        public override IInputController InputController { get; set; }

        public PausedGameState(IInputController IC)
        {
            StateType = GameStateType.Playing;
            InputController = IC;
        }

        public override void Loop()
        {

        }
    }
}