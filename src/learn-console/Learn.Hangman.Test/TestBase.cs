﻿using Learn.Hangman.MenuOptions;
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

        protected virtual IConsole AConsole(ConsoleKey lastKey = ConsoleKey.Enter)
        {
            var mock = new Mock<IConsole>();
            var key = new ConsoleKeyInfo(keyChar: 'a', key: lastKey, false, false, false);
            mock.Setup(t => t.ReadKey()).Returns(key);
            return mock.Object;
        }

        protected virtual IGame AGame() => new Mock<IGame>().Object;

        protected virtual IMenuOption Play(IGame game = null, IConsole console = null) => new Play(new GameRunner(game ?? AGame(), console ?? AConsole()));

        protected virtual IMenuOption Exit(IConsole console = null) => new Exit(console ?? AConsole());
    }
}
