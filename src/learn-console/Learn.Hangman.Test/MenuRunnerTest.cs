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
            var menu = AMenu(
                Exit());
            var menuRunner = new MenuRunner(menu, AConsole(keys: new[]{ConsoleKey.Enter}));
        }
    }
}
