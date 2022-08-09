namespace Learn.Hangman
{
    public class MenuRunner
    {
        private readonly MainMenu menu;
        private readonly EndMenu end;
        private readonly IConsole console;

        public MenuRunner(MainMenu menu, EndMenu end, IConsole console)
        {
            this.console = console;
            this.menu = menu;
            this.end = end;
        }

        public void Run()
        {
            MenuStatus status = MenuStatus.OnMenu;
            while (status != MenuStatus.Done)
            {
                console.Clear();
                console.WriteLine(menu.Render());
                var key = console.ReadKey().Key;
                if (key == ConsoleKey.LeftArrow) menu.Left();
                else if (key == ConsoleKey.RightArrow) menu.Right();
                else if (key == ConsoleKey.Enter) {
                    menu.Enter();
                    console.WriteLine(end.Render());
                    status = end.Option(console.ReadKey());
                }
            }
        }
    }
}
