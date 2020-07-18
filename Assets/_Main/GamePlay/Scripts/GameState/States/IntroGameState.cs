namespace EdwinGameDev
{
    public class IntroGameState : IGameState
    {
        public GameStateType StateType { get; set; }

        public IntroGameState()
        {
            StateType = GameStateType.Intro;
        }

        public void Loop()
        {

        }
    }
}