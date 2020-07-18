namespace EdwinGameDev
{
    public class GameOverGameState : AGameState
    {
        public override GameStateType StateType { get; set; }

        public GameOverGameState()
        {
            StateType = GameStateType.Playing;
        }

        public override void Loop()
        {

        }
    }
}