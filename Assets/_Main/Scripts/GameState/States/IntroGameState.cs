namespace EdwinGameDev
{
    public class IntroGameState : IGameState
    {
        public GameStateType StateType { get; set; }

        public IntroGameState()
        {
            StateType = GameStateType.Playing;
        }

        public void Loop()
        {

        }
    }
}