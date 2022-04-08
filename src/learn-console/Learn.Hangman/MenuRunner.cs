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
            while (mainMenu.GameStatus != GameStatus.Exit)
            {
                console.Clear();
                console.WriteLine(mainMenu.Render());
                mainMenu.ProcessKey(console.ReadKey().Key);
            }

            console.Clear();
        }
    }
}
