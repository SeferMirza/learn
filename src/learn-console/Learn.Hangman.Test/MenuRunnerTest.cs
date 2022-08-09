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
            var menu = Menu(lastStatus:MenuStatus.Done);
            var menuRunner = new MenuRunner(
                menu,
                menu,
                AConsole(keys: new[] { ConsoleKey.S }));

            menuRunner.Run();

            Mock.Get(menu).Verify(m => m.Render(), Times.AtLeastOnce());
        }
    }
}
