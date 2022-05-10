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
                var key = console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow) mainMenu.Left();
                if (key.Key == ConsoleKey.RightArrow) mainMenu.Right();
            }
        }
    }
}
