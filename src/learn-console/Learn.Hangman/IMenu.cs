namespace Learn.Hangman
{
    public interface IMenu
    {
        public void Select();
        GameStatus GameStatus { get; }
        void ProcessKey(ConsoleKey key);
        string Render();
    }
}
