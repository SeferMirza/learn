using Moq;
using System;
using Xunit;

namespace Learn.Hangman.Test
{
    public class MenuRunnerTest
    {
        private ConsoleKeyInfo AKey(char key = '0') => new ConsoleKeyInfo(key, (ConsoleKey)key, false, false, false);

        public IGame AMenu(int tour = 1, GameStatus lastStatus = GameStatus.Exit)
        {
            var mock = new Mock<IGame>();

            var setup = mock.SetupSequence(t => t.GameStatus);
            for (var i = 0; i < tour; i++)
            {
                setup = setup.Returns(GameStatus.MainMenu);
            }

            setup.Returns(lastStatus);

            return mock.Object;
        }

        [Fact]
        public void Program_calisir_menudeki_secenekler_listelenir()
        {
            
        }
    }
}
