namespace EdwinGameDev
{
    public class PausedGameState : AGameState
    {
        public override GameStateType StateType { get; set; }

        public PausedGameState()
        {
            StateType = GameStateType.Playing;
        }

        public override void Loop()
        {

        }
    }
}