using Moq;
using System;
using Xunit;

namespace Learn.Hangman.Test
{
    public class MainMenuTest : TestBase
    {
        [Fact]
        public void Menu_acildiginda_verilen_seceneklerden_ilk_verilen_secenegi_baslangicta_secili_gosterir()
        {
            var menu = AMenu(
                Play(AGame(), AConsole(lastKey: ConsoleKey.Enter)),
                Exit(AConsole()));

            Assert.Contains("Play", menu.Render());
        }

        [Fact]
        public void Kullanici_ilk_secenek_secili_degilken_sol_ok_tusuna_basar_bir_onceki_secenek_goruntulenir()
        {
            var menu = AMenu(
                Play(AGame(), AConsole(lastKey: ConsoleKey.Enter)),
                Exit(AConsole()));
            menu.Right();

            menu.Left();

            Assert.Contains("Play", menu.Render());
        }

        [Fact]
        public void Kullanici_ilk_secenek_secili_degiliyken_sol_ok_tusuna_basar_aynı_secenek_secili_kalir()
        {
            var menu = AMenu(
                Play(AGame(), AConsole(lastKey: ConsoleKey.Enter)),
                Exit(AConsole()));

            menu.Left();

            Assert.Contains("Play", menu.Render());
        }

        [Fact]
        public void Kullanici_sondaki_secenek_secili_degilken_sag_ok_tusuna_basar_sonraki_secenek_goruntulenir()
        {
            var menu = AMenu(
                Play(AGame(), AConsole()),
                Exit(AConsole(lastKey: ConsoleKey.Enter)));

            menu.Right();

            Assert.Contains("Exit", menu.Render());
        }

        [Fact]
        public void Kullanici_sondaki_secenek_seciliyken_sag_ok_tusuna_basar_aynı_secenek_secili_kalir()
        {
            var menu = AMenu(
                Play(AGame(), AConsole()),
                Exit(AConsole(lastKey: ConsoleKey.Enter)));
            menu.Right();

            menu.Right();

            Assert.Contains("Exit", menu.Render());
        }

        [Fact]
        public void Kullanici_Play_secenegini_secer_secenekteki_action_calisir()
        {
            var game = AGame();
            var menu = AMenu(
                Play(game, AConsole(lastKey: ConsoleKey.Enter)),
                Exit(AConsole()));

            menu.Enter();

            Mock.Get(game).Verify(g => g.Render(), Times.AtLeast(1));
        }

        [Fact]
        public void Kullanici_Exit_secenegini_secer_program_sonlanir()
        {
            var game = AGame();
            var console = AConsole(lastKey: ConsoleKey.Enter);
            var menu = AMenu(
                Play(game, console),
                Exit(console));
            menu.Right();

            menu.Enter();

            Mock.Get(console).Verify(g => g.Exit(), Times.AtLeast(1));
        }
    }
}
