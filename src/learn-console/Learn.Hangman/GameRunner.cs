namespace Learn.Hangman
{
    public class GameRunner
    {
        private readonly IGame game;
        private readonly IConsole console;
        public GameRunner(IGame game, IConsole console)
        {
            this.game = game;
            this.console = console;
        }

        public void Run()
        {
            while (game.GameStatus == GameStatus.Play)
            {
                console.Clear();
                console.WriteLine(game.Render());
                game.ProcessKey(console.ReadKey().Key);
                console.Sleep(500);
            }

            console.Clear();
            console.WriteLine(game.Render() + "\n If you want to return menu press 'm' \n If you want to exit press any key");
            var finalKey = console.ReadKey().Key;
            if (finalKey != ConsoleKey.M) console.Exit();
        }
    }
}
