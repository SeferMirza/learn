namespace Learn.Hangman;

public interface IMenuOption
{
    string Title { get; }

    void Select();
}
