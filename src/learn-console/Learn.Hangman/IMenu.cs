namespace Learn.Hangman;

public interface IMenu
{
    void Option(ConsoleKeyInfo keyInfo);
    string Render();
}
