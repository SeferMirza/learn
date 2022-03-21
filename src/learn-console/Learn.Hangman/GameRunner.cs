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

        public bool Run()
        {
            game.Ready();
            while (game.GetGameStatus() == GameStatus.Play)
            {
                console.Clear();
                console.WriteLine(game.Render());
                game.Start(console.ReadKey().Key);
            }

            console.Clear();
            console.WriteLine(game.Render());
            return true;
        }
    }
}
