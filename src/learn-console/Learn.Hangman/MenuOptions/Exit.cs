namespace Learn.Hangman.MenuOptions;

public class Exit : IMenuOption
{
    private readonly IConsole console;

    public Exit(IConsole console) => this.console = console;

    public string Title => nameof(Exit);

    public void Select() => console.Exit();
}
