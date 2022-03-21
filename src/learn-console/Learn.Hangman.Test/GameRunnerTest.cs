using Learn.Hangman.Texts;
using Moq;
using System;
using Xunit;

namespace Learn.Hangman.Test
{
    public class GameRunnerTest
    {
        private Mock<IConsole> mockConsoleIO = new Mock<IConsole>();
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

            mock.Setup(t => t.ReadKey());
            mock.Setup(t => t.WriteLine(It.IsAny<string>()));
            
            return mock.Object;
        }

        [Fact]
        public void Oyunun_kazanilmasi_durumunda_program_kullanicidan_entry_istemiyor()
        {
            GameRunner gameRunner = new GameRunner(AGame(lastStatus: GameStatus.Finish), AConsole());

            gameRunner.Run();

        }
        
        [Fact]
        public void Oyun_baslamadan_once_ready_medhodu_cagirilir()
        {
            GameRunner gameRunner = new GameRunner(AGame(remainingRounds:2,lastStatus:GameStatus.Finish), AConsole());

            gameRunner.Run();
        }

        [Fact]
        public void Kullanici_butun_harfleri_dogru_girer_program_finish_moduna_gecer_son_render_calisir()
        {
            GameRunner gameRunner = new GameRunner(AGame(lastStatus:GameStatus.Finish,remainingRounds:4), AConsole());

            gameRunner.Run();
        }
    }
}
