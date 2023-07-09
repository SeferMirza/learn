namespace Learn.Hangman;

public class MenuRunner
{
    private readonly IMenu menu;
    private readonly IMenu end;
    private readonly IConsole console;

    public MenuRunner(IMenu menu, IMenu end, IConsole console)
    {
        this.console = console;
        this.menu = menu;
        this.end = end;
    }

    public void Run()
    {
        var showMustGoOn = true;
        while (showMustGoOn)
        {
            console.Clear();
            console.WriteLine(menu.Render());
            var keyInfo = console.ReadKey();

            if (keyInfo.Key == ConsoleKey.Escape) showMustGoOn = false;
            
            menu.Option(keyInfo);
            if (keyInfo.Key == ConsoleKey.Enter) {
                console.WriteLine(end.Render());
                end.Option(console.ReadKey());
            }
        }
    }
}
