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

        protected virtual IConsole AConsole(ConsoleKey[] keys)
        {
            var mock = new Mock<IConsole>();
            foreach(var key in keys)
            {
                mock.Setup(t => t.ReadKey()).Returns(new ConsoleKeyInfo(keyChar: 'k', key: key, false, false, false));
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

        protected virtual IMenuOption Play(IGame game = null, IConsole console = null) => new Play(new GameRunner(game ?? AGame(), console ?? AConsole(keys: new[] { ConsoleKey.Enter })));

        protected virtual IMenuOption Exit(IConsole console = null) => new Exit(console ?? AConsole(keys: new[] { ConsoleKey.Enter }));
    }
}
