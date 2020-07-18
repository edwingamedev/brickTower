namespace EdwinGameDev
{
    public class IntroGameState : AGameState
    {
        public override GameStateType StateType { get; set; }

        public IntroGameState()
        {
            StateType = GameStateType.Playing;
        }

        public override void Loop()
        {

        }
    }
}