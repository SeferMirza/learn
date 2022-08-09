using Moq;
using System;
using Xunit;

namespace Learn.Hangman.Test
{
    public class MenuRunnerTest : TestBase
    {
        [Fact]
        public void MenuRunner_calisir_verilen_menu_render_olur()
        {
            var exit = Exit(isClickEnter:true);
            var menuRunner = new MenuRunner(
                AMenu(exit),
                AEndMenu(exit),
                AConsole(keys: new[]{ConsoleKey.Enter, ConsoleKey.E}));

            menuRunner.Run();

            Mock.Get(exit).Verify(m => m.Select(), Times.AtLeastOnce());
        }
    }
}
