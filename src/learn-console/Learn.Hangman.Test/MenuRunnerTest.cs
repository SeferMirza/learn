using Learn.Hangman.MenuOptions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Learn.Hangman.Test
{
    public class MenuRunnerTest : TestBase
    {
        [Fact]
        public void MenuRunner_calisir_verilen_menu_render_olur()
        {
            var game = AGame();
            var menu = AMenu(
                Play(game, AConsole()),
                Exit(AConsole()));
            var menuRunner = new MenuRunner(menu, AConsole(lastKey: ConsoleKey.Enter));

            menuRunner.Run();

            Mock.Get(game).Verify(t => t.Render(), Times.AtLeastOnce());
        }
    }
}
