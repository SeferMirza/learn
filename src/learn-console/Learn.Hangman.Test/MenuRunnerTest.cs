using Learn.Hangman.MenuOptions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Learn.Hangman.Test
{
    public class MenuRunnerTest
    {
        public IGame AGame()
        {
            var mock = new Mock<IGame>();
            mock.Setup(t => t.Render());

            return mock.Object;
        }

        public IConsole AConsole()
        {
            var mock = new Mock<IConsole>();
            ConsoleKeyInfo key = new ConsoleKeyInfo(keyChar: 'a', key: ConsoleKey.Enter, false, false, false);
            mock.Setup(t => t.ReadKey()).Returns(key);
            return mock.Object;
        }

        public MainMenu AMenu(IGame game)
        {
            List<IMenuOption> options = new List<IMenuOption>();
            options.Add(new Play(new GameRunner(game, AConsole())));
            options.Add(new Exit(AConsole()));

            return new MainMenu(options);
        }

        [Fact]
        public void MenuRunner_calisir_verilen_menu_render_olur()
        {
            var game = AGame();
            var menu = AMenu(game);
            MenuRunner menuRunner = new MenuRunner(menu,AConsole());

            menuRunner.Run();

            Mock.Get(game).Verify(t => t.Render(), Times.AtLeastOnce());
        }
    }
}
