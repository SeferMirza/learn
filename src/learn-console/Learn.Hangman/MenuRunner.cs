namespace Learn.Hangman
{
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
            MenuStatus status = MenuStatus.OnMenu;
            while (status != MenuStatus.Done)
            {
                console.Clear();
                console.WriteLine(menu.Render());
                var keyInfo = console.ReadKey();
                status = menu.Option(keyInfo);
                if (keyInfo.Key == ConsoleKey.Enter) {
                    console.WriteLine(end.Render());
                    status = end.Option(console.ReadKey());
                }
            }
        }
    }
}
