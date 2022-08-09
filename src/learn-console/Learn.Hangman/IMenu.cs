namespace Learn.Hangman
{
    public interface IMenu
    {
        MenuStatus Option(ConsoleKeyInfo keyInfo);
        string Render();
    }
}
