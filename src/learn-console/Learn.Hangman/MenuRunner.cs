namespace Learn.Hangman
{
    public class MenuRunner
    {
        private readonly MainMenu menu;
        private readonly IConsole console;

        public MenuRunner(MainMenu menu, IConsole console)
        {
            this.console = console;
            this.menu = menu;
        }

        public void Run()
        {
            while (true)
            {
                console.Clear();
                console.WriteLine(menu.Render());
                var key = console.ReadKey().Key;
                if (key == ConsoleKey.LeftArrow) menu.Left();
                else if (key == ConsoleKey.RightArrow) menu.Right();
                else if (key == ConsoleKey.Enter)
                {
                    menu.Enter();
                    break;
                }
            }
        }
    }
}
