namespace Learn.Hangman;

public class Letter
{
    public char Original { get; private set; }
    public char Masked { get; private set; }

    public Letter(char letter)
    {
        Original = letter;
        Masked = '_';

        if (letter == ' ') Reveal();
    }

    public bool Is(ConsoleKey key) => Original == (char)key;
    public void Reveal() => Masked = Original;
    public bool Revealed => Masked == Original;

    public override string ToString() => $"{Masked}";
}
