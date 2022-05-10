namespace Learn.Hangman
{
    public class MenuRunner
    {
        private readonly IMenu mainMenu;
        private readonly IConsole console;

        public MenuRunner(IMenu mainMenu, IConsole console)
        {
            this.console = console;
            this.mainMenu = mainMenu;
        }

        public void Run()
        {
            while (true)
            {
                console.Clear();
                console.WriteLine(mainMenu.Render());
                var key = console.ReadKey().Key;
                if (key == ConsoleKey.LeftArrow) mainMenu.Left();
                else if (key == ConsoleKey.RightArrow) mainMenu.Right();
                else if (key == ConsoleKey.Enter) mainMenu.Enter();
            }
        }
    }
}
