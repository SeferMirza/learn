namespace Learn.Hangman.Consoles;

public class SystemConsole : IConsole
{
    public void Clear() => Console.Clear();

    public void Exit() => Environment.Exit(0);

    public ConsoleKeyInfo ReadKey() => Console.ReadKey();

    public void Sleep(int milliseconds) => Thread.Sleep(milliseconds);

    public void WriteLine(string message) => Console.WriteLine(message);
}
