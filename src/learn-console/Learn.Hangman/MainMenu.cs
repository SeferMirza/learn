using Learn.Hangman.Consoles;
using Learn.Hangman.Models;

namespace Learn.Hangman
{
    public class MainMenu
    {
        private readonly List<IMenuOption> menus;
        IMenuOption currentMenu;
        private int currentIndex = 0;
        public MainMenu(List<IMenuOption> menus)
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
            //TODO - ?
            var leftArrow = currentMenu.Title == "Play" ? " " : "<";
            var rightArrow = currentMenu.Title == "Exit" ? " " : ">";

            return leftArrow + new string(' ', (9 - currentMenu.Title.Length) / 2) +
                currentMenu.Title +
                new string(' ', (9 - currentMenu.Title.Length) / 2) + rightArrow;
        }
    }
}
