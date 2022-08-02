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
            var play = Play(isClickEnter:true);
            var menu = AMenu(
                play,
                Exit());
            var endMenuList = AEndMenu(
                Exit());
            var menuRunner = new MenuRunner(menu, endMenuList, AConsole(keys: new[]{ConsoleKey.Enter}));

            menuRunner.Run();

            Mock.Get(play).Verify(m => m.Select(), Times.AtLeastOnce());
        }
    }
}
