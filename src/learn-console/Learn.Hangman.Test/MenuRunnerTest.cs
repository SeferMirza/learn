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
            List<IMenuOption> endmenulist = new();
            endmenulist.Add(Exit());
            var endMenu = new EndMenu(endmenulist);

            var menuRunner = new MenuRunner(menu, endMenu, AConsole(keys: new[]{ConsoleKey.Enter}));
        }
    }
}
