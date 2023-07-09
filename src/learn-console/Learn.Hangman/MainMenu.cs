namespace Learn.Hangman;

public class MainMenu : IMenu
{
    private readonly List<IMenuOption> menuOptions;
    private int currentIndex = 0;
    public MainMenu(List<IMenuOption> menuOptions)
    {
        this.menuOptions = menuOptions;
    }

    private readonly int MAX_MENU_OPTION_SIZE = 9;

    public string Render()
    {
        var leftArrow = currentIndex == 0 ? " " : "<";
        var rightArrow = currentIndex == menuOptions.Count() - 1 ? " " : ">";

        return leftArrow + new string(' ', (MAX_MENU_OPTION_SIZE - menuOptions[currentIndex].Title.Length) / 2) +
            menuOptions[currentIndex].Title +
            new string(' ', (MAX_MENU_OPTION_SIZE - menuOptions[currentIndex].Title.Length) / 2) + rightArrow;
    }

    public void Option(ConsoleKeyInfo keyInfo = default)
    {
        if (keyInfo.Key == ConsoleKey.RightArrow && currentIndex < menuOptions.Count() - 1) currentIndex++;
        else if (keyInfo.Key == ConsoleKey.LeftArrow && currentIndex > 0) currentIndex--;
        else if (keyInfo.Key == ConsoleKey.Enter)
        {
            menuOptions[currentIndex].Select();
        }
    }
}
