namespace EdwinGameDev
{
    public class GameOverGameState : IGameState
    {
        public GameStateType StateType { get; set; }

        public GameOverGameState()
        {
            StateType = GameStateType.Playing;
        }

        public void Loop()
        {

        }
    }
}