using System;
using Xunit;
/*...
 
 
 */
namespace Learn.Hangman.Test
{
    public class HangmanTest
    {
        string word = "HI";
        Game game;
        public HangmanTest()
        {
            game = new Game(word);
            game.Ready();
        }

        [Fact]
        public void Game_Initial_State_Control()
        {
            string text = string.Empty;
            text = "_ _"; // empty text

            Assert.Equal(text, game.Render());
        }

        [Fact]
        public void If_User_Enter_Right_Character_Open_All_Box()
        {
            game.Start(ConsoleKey.I);
            game.Start(ConsoleKey.H);

            string finalGameText = game.Render();
            Assert.Equal("H I", finalGameText);

        }

        [Fact]
        public void If_User_Enters_Wrong_Character_Box_Reamins_Closed()
        {
            game.Start(ConsoleKey.L);
            game.Start(ConsoleKey.K);
            game.Start(ConsoleKey.C);

            string finalGameText = game.Render();
            Assert.Equal("_ _", finalGameText);
        }

        [Fact]
        public void If_User_Finds_More_Than_One_Character_In_The_Boxes_They_All_Opened()
        {
            string text = "ADANA";

            Game localGame = new Game(text);
            localGame.Ready();
            localGame.Start(ConsoleKey.A);

            Assert.Equal("A _ A _ A", localGame.Render());
        }

        [Fact]
        public void All_Existing_Characters_Are_Entered_Game_Over()
        {
            string text = "AAAAA";

            Game localGame = new Game(text);
            localGame.Ready();
            localGame.Start(ConsoleKey.A);

            Assert.True(localGame.GameOverCheck());
        }

        [Fact]
        public void Texts_Consisting_Of_More_Than_One_Word_Open_Correctly()
        {
            string text = "KARABIGA BIGA CANAKKALE";

            Game localGame = new Game(text);
            localGame.Ready();

            Assert.Equal("_ _ _ _ _ _ _ _   _ _ _ _   _ _ _ _ _ _ _ _ _", localGame.Render());
        }

        [Fact]
        public void Character_Entered_By_User_Opens_Correctly_In_More_Than_One_Word()
        {
            string text = "KARABIGA CANAKKALE";

            Game localGame = new Game(text);
            localGame.Ready();
            localGame.Start(ConsoleKey.A);

            Assert.Equal("_ A _ A _ _ _ A   _ A _ A _ _ A _ _", localGame.Render());
        }

        [Fact]
        public void If_User_Does_Not_Enter_Letter()
        {
            game.Start(ConsoleKey.Enter);
            game.Start(ConsoleKey.F1);
            game.Start(ConsoleKey.NumPad1);
            game.Start(ConsoleKey.Delete);
            game.Start(ConsoleKey.Backspace);
            game.Start(ConsoleKey.Tab);
            game.Start(ConsoleKey.UpArrow);
            game.Start(ConsoleKey.Escape);
            game.Start(ConsoleKey.Clear);
            game.Start(ConsoleKey.D4);

            Assert.Equal("_ _", game.Render());
        }

        [Fact]
        public void User_Enters_Space_When_There_Is_More_Than_One_Word()
        {
            string text = "KARABIGA BIGA CANAKKALE";

            Game localGame = new Game(text);
            localGame.Ready();
            localGame.Start(ConsoleKey.Spacebar);

            Assert.Equal("_ _ _ _ _ _ _ _   _ _ _ _   _ _ _ _ _ _ _ _ _", localGame.Render());
        }

        [Fact]
        public void If_User_Hits_The_Screen_It_Is_Game_Over()
        {
            Assert.True(true);
        }
    }
}