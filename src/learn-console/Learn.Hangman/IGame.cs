namespace Learn.Hangman;

public interface IGame
{
    GameStatus GameStatus { get; }
    void ProcessKey(ConsoleKey key);
    string Render();
    }
