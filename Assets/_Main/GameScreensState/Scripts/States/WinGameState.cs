namespace EdwinGameDev
{
    public class WinGameState : AGameState
    {
        public WinGameState(GameScreenSettings screenSettings)
        {
            StateType = GameStateType.Win;
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