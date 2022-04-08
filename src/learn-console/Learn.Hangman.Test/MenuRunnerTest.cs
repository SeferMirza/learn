using Learn.Hangman.Lists;
using Moq;
using System;
using Xunit;

namespace Learn.Hangman.Test
{
    public class MenuRunnerTest
    {
        //TODO - Play durumundaki testleri yaz
        private ConsoleKeyInfo AKey(char key = '0') => new ConsoleKeyInfo(key, (ConsoleKey)key, false, false, false);

        public IConsole AConsole(int tour = 1)
        {
            var mock = new Mock<IConsole>();
            var setup = mock.SetupSequence(t => t.ReadKey());
            for (var i = 0; i < tour; i++)
            {
                setup.Returns(AKey((char)ConsoleKey.DownArrow));
            }

            setup.Returns(AKey((char)ConsoleKey.Enter));

            return mock.Object;
        }

        public IMenu AMenu(int tour = 1, GameStatus lastStatus = GameStatus.Exit)
        {
            var mock = new Mock<IMenu>();
            var setup = mock.SetupSequence(t => t.GameStatus);
            for (var i = 0; i < tour; i++)
            {
                setup = setup.Returns(GameStatus.Play);
            }
            setup.Returns(lastStatus);

            return mock.Object;
        }

        public MainMenu AMenu()
        {
            var menuList = new MenuList();

            MainMenu mainMenu = new MainMenu(menuList.GetMainMenu());

            return mainMenu;
        }

        [Fact]
        public void Kullanici_exit_secenegini_secer_menu_tekrar_gosterilmez()
        {
            var mockConsole = AConsole(1);
            MenuRunner menu = new MenuRunner(AMenu(), mockConsole);

            menu.Run();

            Mock.Get(mockConsole).Verify(t => t.WriteLine(It.IsAny<string>()), Times.AtLeast(2));
        }

        [Fact]
        public void Kullanici_exit_secenegini_secer_oyun_cikis_moduna_gecer()
        {
            var mockConsole = AConsole(1);
            var aMenu = AMenu();
            MenuRunner menu = new MenuRunner(aMenu, mockConsole);

            menu.Run();

            Assert.Equal(GameStatus.Exit, aMenu.GameStatus);
        }


    }
}
