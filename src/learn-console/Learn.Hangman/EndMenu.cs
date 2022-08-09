﻿namespace Learn.Hangman
{
    public class EndMenu: IMenu
    {
        private readonly List<IMenuOption> menuOptions;
        public EndMenu(List<IMenuOption> menuOptions)
        {
            this.menuOptions = menuOptions;
        }

        public MenuStatus Option(ConsoleKeyInfo keyInfo)
        {
            menuOptions.Where(x => char.ToLower(x.Title[0]) == char.ToLower(keyInfo.Key.ToString().First())).First().Select();

            return MenuStatus.OnMenu;
        }

        public string Render() => string.Join(", ", menuOptions.Select(x => x.Title + $"['{x.Title.First()}']"));
    }
}
