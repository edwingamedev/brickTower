namespace EdwinGameDev
{
    public enum InputType
    {
        // Regular Inputs
        RotateBlock,
        MoveBlockLeft,
        MoveBlockRight,
        MoveBlockDown,

        // Game Master's Inputs
        AddLife,
        RemoveLife,
        SpawnRandomBlock,
        RedoLastPlay,
        ResetCurrentBlock
    }
}