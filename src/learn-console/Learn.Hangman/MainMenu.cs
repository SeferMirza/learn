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
            var menu = new Menus();
            return string.Join(Environment.NewLine, menu.MainMenu);
        }

        public void Select()
        {
            
        }
    }
}
