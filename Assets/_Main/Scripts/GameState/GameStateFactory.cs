namespace EdwinGameDev
{
    public class GameStateFactory
    {
        private IGameState gameState;

        public GameStateFactory()
        {

        }

        public IGameState MakeGameState(GameStateType stateType, IInputController inputController)
        {
            switch (stateType)
            {
                default:
                case GameStateType.Intro:
                    gameState = new IntroGameState(inputController);
                    break;
                case GameStateType.Playing:
                    gameState = new PlayingGameState(inputController);
                    break;
                case GameStateType.Paused:
                    gameState = new PausedGameState(inputController);
                    break;
                case GameStateType.GameOver:
                    gameState = new GameOverGameState(inputController);
                    break;
                case GameStateType.GameMaster:
                    gameState = new GameMasterState(inputController as GameMasterInputController);
                    break;
            }

            return gameState;
        }
    }
}