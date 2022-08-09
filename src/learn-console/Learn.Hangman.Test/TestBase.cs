using Learn.Hangman.MenuOptions;
using Moq;
using System;
using System.Collections.Generic;

namespace Learn.Hangman.Test
{
    public abstract class TestBase
    {
        protected virtual MainMenu AMenu(params IMenuOption[] options)
        {
            var menuOptions = new List<IMenuOption>();
            foreach (var option in options)
            {
                menuOptions.Add(option);
            }

            return new MainMenu(menuOptions);
        }
        private ConsoleKeyInfo AKey(char key = '0') => new ConsoleKeyInfo(key, (ConsoleKey)key, false, false, false);

        protected virtual IMenu Menu()
        {
            var mock = new Mock<IMenu>();
            mock.Setup(m => m.Option());
            mock.Setup(m => m.Render());

            return mock.Object;
        }

        protected virtual IConsole AConsole(ConsoleKey[] keys)
        {
            var mock = new Mock<IConsole>();
            mock.Setup(t => t.Exit());
            var setup = mock.SetupSequence(t => t.ReadKey());
            foreach (var key in keys)
            {
                setup = setup.Returns(new ConsoleKeyInfo(keyChar: 'k', key: key, false, false, false));
            }
            return mock.Object;
        }

        protected virtual IGame AGame(int remainingRounds = 1, GameStatus lastStatus = GameStatus.Won)
        {
            var mock = new Mock<IGame>();

            var setup = mock.SetupSequence(t => t.GameStatus);
            for (var i = 0; i < remainingRounds; i++)
            {
                setup = setup.Returns(GameStatus.Play);
            }

            setup.Returns(lastStatus);

            return mock.Object;
        }

        protected virtual EndMenu AEndMenu(params IMenuOption[] options)
        {
            var menuOptions = new List<IMenuOption>();
            foreach (var option in options)
            {
                menuOptions.Add(option);
            }

            return new EndMenu(menuOptions);
        }

        protected virtual IMenuOption Play(bool isClickEnter = false)
        {
            var mock = new Mock<IMenuOption>();
            mock.Setup(m => m.Title).Returns("Play");
            if (isClickEnter) mock.Setup(m => m.Select());

            return mock.Object;
        }

        protected virtual IMenuOption Exit(bool isClickEnter = false)
        {
            var mock = new Mock<IMenuOption>();
            mock.Setup(m => m.Title).Returns("Exit");
            if (isClickEnter) mock.Setup(m => m.Select());

            return mock.Object;
        }
    }
}
