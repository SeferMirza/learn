namespace Learn.Hangman
{
    public interface IConsole
    {
        void WriteLine(string message);
        void Clear();
        ConsoleKeyInfo ReadKey();
        void Sleep(int milliseconds);
        void Exit();
    }
}
