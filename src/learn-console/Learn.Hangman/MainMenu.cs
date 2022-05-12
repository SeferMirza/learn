namespace Learn.Hangman
{
    public class MainMenu
    {
        private readonly List<IMenuOption> menuOptions;
        private int currentIndex = 0;
        public MainMenu(List<IMenuOption> menuOptions)
        {
            this.menuOptions = menuOptions;
        }

        public void Enter()
        {
            menuOptions[currentIndex].Select();
        }

        public void Left()
        {
            if (currentIndex > 0) currentIndex--;
        }

        public void Right()
        {
            if (currentIndex < menuOptions.Count() - 1) currentIndex++;
        }

        private readonly int MAX_MENU_OPTION_SIZE = 9;

        public string Render()
        {
            var leftArrow = currentIndex == 0 ? " " : "<";
            var rightArrow = currentIndex == menuOptions.Count() - 1 ? " " : ">";

            return leftArrow + new string(' ', (MAX_MENU_OPTION_SIZE - menuOptions[currentIndex].Title.Length) / 2) +
                menuOptions[currentIndex].Title +
                new string(' ', (MAX_MENU_OPTION_SIZE - menuOptions[currentIndex].Title.Length) / 2) + rightArrow;
        }
    }
}
