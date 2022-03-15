using System;
using Xunit;

namespace Learn.Hangman.Test
{
    public class HangmanTest
    {
        string word = "ISTANBUL";
        Game game;
        public HangmanTest()
        {
            game = new Game(word);
            game.Ready();
        }

        [Fact]
        public void Hangman_Render_Kelime_Return_String_Test()
        {
            //Oyun başlangıç durumunun doğruluğu kontrolü
            string text = string.Empty;
            text = "_ _ _ _ _ _ _ _"; // empty text

            Assert.Equal(text,game.Render());
        }

        [Fact]
        public void Hangman_Start_Kelime_Tahmin_Test()
        {
            //İstenen text içerisine tüm karakterlerin doğru girilmesi durumunda text içerisindeki karakter varlığı kontrolü
            ConsoleKey[] consoleKeys =
            {
                ConsoleKey.I,
                ConsoleKey.S,
                ConsoleKey.T,
                ConsoleKey.A,
                ConsoleKey.N,
                ConsoleKey.B,
                ConsoleKey.U,
                ConsoleKey.L,
            };

            for(var index=0;index<consoleKeys.Length;index++)
            {
                game.Start(consoleKeys[index]);
                string finalGameText = game.Render();
                Assert.Equal(consoleKeys[index].ToString(),finalGameText[index*2].ToString());
            }
        }

        [Fact]
        public void Hangman_Different_Character_Entry_Test()
        {
            //İstenen text içerisinde olmayan bir karakter girilmesi durumunda text içerisinde o karakterin varlığı kontrolü
            game.Start(ConsoleKey.K);
            string finalGameText = game.Render();
            
            for (var index = 0; index < finalGameText.Length; index++)
            {
                Assert.False(finalGameText[index].ToString() == ConsoleKey.K.ToString());
            }
        }
    }
}