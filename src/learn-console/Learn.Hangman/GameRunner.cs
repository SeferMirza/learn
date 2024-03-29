namespace Learn.Hangman;

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
        console.WriteLine(game.Render());
        console.Sleep(300);
    }
    }
