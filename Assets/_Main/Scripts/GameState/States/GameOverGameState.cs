namespace EdwinGameDev
{
    public class GameOverGameState : AGameState
    {
        public override GameStateType StateType { get; set; }
        public override IInputController InputController { get; set; }

        public GameOverGameState(IInputController IC)
        {
            StateType = GameStateType.Playing;
            InputController = IC;
        }

        public override void Loop()
        {

        }
    }
}