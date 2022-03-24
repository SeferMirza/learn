using Learn.Hangman.Texts;
using Moq;
using System;
using Xunit;

namespace Learn.Hangman.Test
{
    public class GameRunnerTest
    {
        private ConsoleKeyInfo AKey(char key = '0') => new ConsoleKeyInfo(key, (ConsoleKey)key, false, false, false);

        public IGame AGame(int remainingRounds = 1, GameStatus lastStatus = GameStatus.Won)
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
            var game = AGame(lastStatus: GameStatus.Won, remainingRounds: 1);
            GameRunner gameRunner = new GameRunner(game, console);

            gameRunner.Run();

            Mock.Get(game).Verify(t => t.Render(), Times.AtLeastOnce());
            Mock.Get(console).Verify(t => t.ReadKey(), Times.AtLeastOnce());
        }

        [Fact]
        public void Oyun_bitene_kadar_kullaniciya_gorsel_gosterilmeye_ve_harf_istenmeye_devam_edilir()
        {
            var console = AConsole();
            var game = AGame(lastStatus: GameStatus.Won, remainingRounds: 2);
            GameRunner gameRunner = new GameRunner(game, console);

            gameRunner.Run();

            Mock.Get(game).Verify(t => t.Render(), Times.AtLeast(2));
            Mock.Get(console).Verify(t => t.ReadKey(), Times.AtLeast(2));
        }

        [Fact]
        public void Oyun_bittiginde_son_bir_gorsel_daha_gosterilir()
        {
            var console = AConsole();
            var game = AGame(lastStatus: GameStatus.Won, remainingRounds: 0);
            GameRunner gameRunner = new GameRunner(game, console);

            gameRunner.Run();

            Mock.Get(game).Verify(t => t.Render(), Times.AtLeastOnce());
        }
    }
}
