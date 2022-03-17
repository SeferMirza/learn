namespace Learn.Hangman
{
    public class GameRunner
    {
        private readonly Game game;
        private readonly IConsole console;

        public GameRunner(Game game, IConsole console)
        {
            this.game = game;
            this.console = console;
        }

        public void Run()
        {
            game.Ready();
            while (game.GameStatus == GameStatus.Play)
            {
                console.Clear();
                console.WriteLine(game.Render());
                game.Start(console.ReadKey().Key);
            }

            console.Clear();
            console.WriteLine(game.Render());
        }
    }
}
