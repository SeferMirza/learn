using Learn.Hangman.Consoles;
using Learn.Hangman.Models;

namespace Learn.Hangman
{
    public class MainMenu : IMenu
    {
        private readonly List<IMenuOptionsEvent> menus;
        IMenuOptionsEvent currentMenu;
        private int currentIndex = 0;
        public MainMenu(List<IMenuOptionsEvent> menus)
        {
            currentMenu = menus.First();
            this.menus = menus;
        }

        public void Enter()
        {
            currentMenu.Select();
        }

        public void Left()
        {
            currentIndex--;
            if (currentIndex < 0) currentIndex = 0;
            currentMenu = menus.Skip(currentIndex).First();
        }

        public void Right()
        {
            currentIndex++;
            if (currentIndex == menus.Count) currentIndex = menus.Count - 1;
            currentMenu = menus.Skip(currentIndex).First();
        }

        public string Render()
        {
            return "<" + new string(' ', (9 - currentMenu.Title.Length) / 2) +
                currentMenu.Title +
                new string(' ', (9 - currentMenu.Title.Length) / 2) + ">";
        }
    }
}
