using Learn.Hangman.Consoles;
using Learn.Hangman.Models;

namespace Learn.Hangman
{
    public class MainMenu : IMenu
    {
        public GameStatus GameStatus { get; private set; }
        public List<Menu> Menus { get;private set; }
        public int Position { get;private set; }
        private IGame game;
        private IConsole console;
        private GameRunner runner;
        public MainMenu(List<Menu> menus)
        {
            this.Menus = menus;
            Position = 0;
            game = new GameFactory().CreateDefault();
            console = new SystemConsole();
            runner = new GameRunner(game, console);
        }

        public void ProcessKey(ConsoleKey key)
        {
            if (key == ConsoleKey.Enter) Select();
            else if(key == ConsoleKey.UpArrow) Position = Position <= 0 ? (Menus.Count - 1) : (Position - 1);
            else if(key == ConsoleKey.DownArrow) Position = Position >= (Menus.Count - 1) ? 0 : (Position + 1);
        }

        public string Render()
        {      
            return string.Join("\n",Menus.Select(x => x.Id == (Position) ? (">>" + x.Title) : ("  " + x.Title)));
        }

        public void Select()
        {
            if(Menus.Where(x => x.Id == (Position)).Select(x  => x.Title).First() == "Play")
            {
                GameStatus = GameStatus.Play;
                runner.Run();
            }
            else if(Menus.Where(x => x.Id == (Position)).Select(x => x.Title).First() == "Exit")
            {
                GameStatus = GameStatus.Exit;
                Environment.Exit(0);
            }
        }
    }
}
