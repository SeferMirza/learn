namespace Learn.Hangman.Consoles
{
    public class SystemConsole : IConsole
    {
        public void Clear() => Console.Clear();
        public ConsoleKeyInfo ReadKey() => Console.ReadKey();
        public void WriteLine(string message) => Console.WriteLine(message);
    }
}
