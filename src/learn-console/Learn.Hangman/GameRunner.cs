namespace Learn.Hangman
{
    public class GameRunner
    {
        private readonly IGameFactory gameFactory;
        private readonly IConsole console;
        public GameRunner(IGameFactory gameFactory, IConsole console)
        {
            this.gameFactory = gameFactory;
            this.console = console;
        }

        public void Run()
        {
            var game = gameFactory.CreateDefault();
            while (game.GameStatus == GameStatus.Play)
            {
                console.Clear();
                console.WriteLine(game.Render());
                game.ProcessKey(console.ReadKey().Key);
                console.Sleep(500);
            }

            console.Clear();
            console.WriteLine(game.Render());
        }
    }
}
