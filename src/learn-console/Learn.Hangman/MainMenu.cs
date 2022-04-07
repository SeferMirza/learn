using Learn.Hangman.Consoles;
using Learn.Hangman.Models;

namespace Learn.Hangman
{
    public class MainMenu : IMenu, IGame
    {
        public GameStatus GameStatus { get; private set; }
        public string[] Menus { get;private set; }
        public int Position { get;private set; }
        public MainMenu(string[] menus)
        {
            this.Menus = menus;
        }

        public void Load() { }

        public void ProcessKey(ConsoleKey key)
        {
            if (key == ConsoleKey.Enter) Select();
            else if(key == ConsoleKey.UpArrow) Position = Position <= 0 ? (Menus.Length - 1) : (Position - 1);
            else if(key == ConsoleKey.DownArrow) Position = Position >= (Menus.Length - 1) ? 0 : (Position + 1);
        }

        public string Render()
        {
            string res = "";

            for (int i = 0; i < Menus.Length; i++)
            {
                Console.ResetColor();
                if(i == Position)
                {
                    res += ">>" + Menus[i] + Environment.NewLine;
                }
                else
                {
                    res += "  " + Menus[i] + Environment.NewLine;
                }
            }
            
            return res;
        }

        public void Select()
        {
            if(Menus[Position] == "Play")
            {
                var game = new GameFactory().CreateDefault();
                var console = new SystemConsole();
                var runner = new GameRunner(game, console);

                runner.Run();
            }
        }
    }
}
