public class GameMasterInputController : IInputController
{
    public GameContainer gameContainer;
    private GameSessionController gameSessionController;

    public GameMasterInputController(GameContainer gameContainer, GameSessionController gameSessionController)
    {
        this.gameContainer = gameContainer;
        this.gameSessionController = gameSessionController;
    }

    public void ProcessInput(InputType input)
    {
        switch (input)
        {
            case InputType.AddLife:
                AddLife();
                break;

            case InputType.RemoveLife:
                RemoveLife();
                break;

            case InputType.SpawnRandomBlock:
                SpawnRandomBlock();
                break;

            case InputType.RedoLastPlay:
                RedoLastPlay();
                break;

            case InputType.ResetCurrentBlock:
                ResetCurrentBlock();
                break;

            default:
                break;
        }
    }

    public void AddLife()
    {
        
    }

    public void RedoLastPlay()
    {
        
    }

    public void RemoveLife()
    {
        
    }

    public void ResetCurrentBlock()
    {
        
    }

    public void SpawnBlock(int value)
    {
        
    }

    public void SpawnRandomBlock() 
    { 

    }
}
