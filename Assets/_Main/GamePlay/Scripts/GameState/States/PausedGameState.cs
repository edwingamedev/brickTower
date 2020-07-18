namespace EdwinGameDev
{
    public class PausedGameState : IGameState
    {
        public GameStateType StateType { get; set; }

        public PausedGameState()
        {
            StateType = GameStateType.Paused;
        }

        public void Loop()
        {

        }
    }
}