namespace EdwinGameDev
{
    public class GameStateFactory
    {
        private IGameState gameState;

        public GameStateFactory()
        {

        }

        public IGameState MakeGameState(GameStateType stateType)
        {
            switch (stateType)
            {
                default:
                case GameStateType.Intro:
                    gameState = new IntroGameState();
                    break;
                case GameStateType.Playing:
                    gameState = new PlayingGameState();
                    break;
                case GameStateType.Paused:
                    gameState = new PausedGameState();
                    break;
                case GameStateType.GameOver:
                    gameState = new GameOverGameState();
                    break;
            }

            return gameState;
        }
    }
}