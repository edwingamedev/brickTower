namespace EdwinGameDev
{
    public interface IInputProcessor
    {
        bool Down();
        bool Left();
        bool Right();
        bool Up();
        bool Click();
        bool Release();
        bool Hold();
    }
}