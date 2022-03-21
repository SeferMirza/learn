using Learn.Hangman.Texts;
using Moq;
using System;
using Xunit;

namespace Learn.Hangman.Test
{
    public class GameRunnerTest
    {
        private ConsoleKeyInfo AKey(char key = '0') => new ConsoleKeyInfo(key, (ConsoleKey)key, false, false, false);

        public IGame AGame(int remainingRounds = 1, GameStatus lastStatus = GameStatus.Finish)
        {
            var mock = new Mock<IGame>();
            
            var setup = mock.SetupSequence(t => t.GetGameStatus());
            for (var i = 0; i < remainingRounds; i++)
            {
                setup = setup.Returns(GameStatus.Play);
            }

            setup.Returns(lastStatus);

            return mock.Object;
        }

        public IConsole AConsole()
        {
            var mock = new Mock<IConsole>();

            mock.Setup(t => t.ReadKey()).Returns(AKey());

            return mock.Object;
        }

        [Fact]
        public void Oyun_basladiginda_kullaniciya_gorsel_gosterir_ve_bir_harf_istenir()
        {
            var console = AConsole();
            var game = AGame(lastStatus: GameStatus.Finish, remainingRounds:1);
            GameRunner gameRunner = new GameRunner(game, console);

            gameRunner.Run();

            Mock.Get(game).Verify(t=> t.Render());
            Mock.Get(console).Verify(t => t.ReadKey());
        }

        [Fact]
        public void Kullanici_harf_girer_gorsel_gosterilir_oyun_sonlanir()
        {
            var console = AConsole();
            var game = AGame(lastStatus: GameStatus.Finish, remainingRounds: 1);
            GameRunner gameRunner = new GameRunner(game, console);

            gameRunner.Run();

            Mock.Get(game).Verify(t => t.Render(),Times.Exactly(2));
            Mock.Get(console).Verify(t => t.ReadKey(),Times.Once());
        }

        [Fact]
        public void Oyun_sonlanir_son_gorsel_gosterilir()
        {
            var console = AConsole();
            var game = AGame(lastStatus: GameStatus.Finish, remainingRounds: 0);
            GameRunner gameRunner = new GameRunner(game, console);

            gameRunner.Run();

            Mock.Get(console).Verify(t => t.ReadKey(), Times.Never());
            Mock.Get(game).Verify(t => t.Render(),Times.Exactly(1));
        }
    }
}
