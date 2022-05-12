using Learn.Hangman.Consoles;
using Learn.Hangman.MenuOptions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Learn.Hangman.Test
{
    public class MainMenuTest
    {
        private List<IMenuOption> AList()
        {
            List<IMenuOption> options = new List<IMenuOption>();
            options.Add(new Play(new GameRunner(AGame(), AConsole())));
            options.Add(new Exit(AConsole()));
            return options;
        }
        public IGame AGame() {
            var mock = new Mock<IGame>();
            mock.Setup(t => t.Render());

            return mock.Object;
        }
        public IConsole AConsole() {
            var mock = new Mock<IConsole>();
            ConsoleKeyInfo key = new ConsoleKeyInfo(keyChar:'a', key:ConsoleKey.Enter,false,false,false);
            mock.Setup(t => t.ReadKey()).Returns(key);
            mock.Setup(t => t.Clear());
            return mock.Object;
        }

        public MainMenu AMenu(List<IMenuOption> optionsList) => new MainMenu(optionsList);

        [Fact]
        public void Menu_acildiginda_Play_secenegi_baslangicta_gelir()
        {
            List<IMenuOption> options = new List<IMenuOption>();
            options.Add(new Play(new GameRunner(AGame(), AConsole())));
            options.Add(new Exit(AConsole()));
            var menu = AMenu(options);
      
            Assert.Contains("Play", menu.Render());
        }

        [Fact]
        public void Kullanici_Play_seceneginde_degilken_sol_ok_tusuna_basar_Menude_goruntulenen_sekme_bir_gerideki_olur()
        {
            List<IMenuOption> options = new List<IMenuOption>();
            options.Add(new Play(new GameRunner(AGame(), AConsole())));
            options.Add(new Exit(AConsole()));
            var menu = AMenu(options);
            menu.Right();
            
            menu.Left();

            Assert.Contains("Play", menu.Render());
        }

        [Fact]
        public void Kullanici_sag_ok_tusuna_basar_Menude_goruntulenen_secenek_bir_sonraki_olur()
        {
            List<IMenuOption> options = new List<IMenuOption>();
            options.Add(new Play(new GameRunner(AGame(), AConsole())));
            options.Add(new Exit(AConsole()));
            var menu = AMenu(options);

            menu.Right();

            Assert.Contains("Exit", menu.Render());
        }

        [Fact]
        public void Kullanici_Play_secenegini_secer_Game_calisir()
        {
            var game = AGame();
            List<IMenuOption> options = new List<IMenuOption>();
            options.Add(new Play(new GameRunner(game, AConsole())));
            options.Add(new Exit(AConsole()));
            var menu = AMenu(options);

            menu.Enter();

            Mock.Get(game).Verify(g => g.Render(), Times.AtLeast(1));
        }

        [Fact]
        public void Kullanici_Exit_secenegini_secer_program_sonlanir()
        {
            var game = AGame();
            var console = AConsole();
            List<IMenuOption> options = new List<IMenuOption>();
            options.Add(new Play(new GameRunner(game, console)));
            options.Add(new Exit(console));
            var menu = AMenu(options);
            menu.Right();

            menu.Enter();

            Mock.Get(console).Verify(g => g.Exit(), Times.AtLeast(1));
        }
    }
}
