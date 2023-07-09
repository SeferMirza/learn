namespace Learn.Hangman;

public class EndMenu: IMenu
{
    private readonly List<IMenuOption> menuOptions;
    public EndMenu(List<IMenuOption> menuOptions)
    {
        this.menuOptions = menuOptions;
    }

    public void Option(ConsoleKeyInfo keyInfo)
    {
        var option = menuOptions.Where(x => char.ToLower(x.Title[0]) == char.ToLower(keyInfo.Key.ToString().First()));

        option.First().Select();
    }

    public string Render() => string.Join(", ", menuOptions.Select(x => x.Title + $"['{x.Title.First()}']"));
}
