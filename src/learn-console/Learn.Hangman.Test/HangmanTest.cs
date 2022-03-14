using Xunit;
using Xunit.Sdk;

namespace Learn.Hangman.Test
{
    public class HangmanTest
    {

        [Fact]
        public void Hangman_Render_Kelime_Return_String_Test()
        {
            Game game = new Game();
            game.Ready();
            string text = string.Empty;
            text = "_ _ _ _ _ _ _"; // empty text
            Assert.Equal(text,game.Render());
        }

        [Fact]
        public void Hangman_Start_Kelime_Tahmin_Test()
        {

            throw new XunitException("Fail. Later...");
        }
    }
}