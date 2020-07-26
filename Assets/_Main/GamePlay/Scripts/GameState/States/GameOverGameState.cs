namespace EdwinGameDev
{
    public class GameOverGameState : AGameState
    {
        public GameOverGameState(GameScreenSettings screenSettings)
        {
            StateType = GameStateType.GameOver;
            this.screenSettings = screenSettings;
        }

        public override void Execute(StateCommandType stateCommandType)
        {
            {
                switch (stateCommandType)
                {
                    case StateCommandType.OpenScene:
                        StartScene(stateCommandType);
                        break;
                    case StateCommandType.StartGame:
                        ChangeScene(stateCommandType);
                        break;
                    case StateCommandType.GoToMenu:
                        ChangeScene(stateCommandType);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}