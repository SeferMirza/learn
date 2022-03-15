using System;
using Xunit;

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
        public void Game_initial_state_control()
        {
            string text = string.Empty;
            text = "_ _"; // empty text

            Assert.Equal(text, game.Render());
        }

        [Fact]
        public void If_user_enter_right_character_open_all_box()
        {
            game.Start(ConsoleKey.I);
            game.Start(ConsoleKey.H);

            string finalGameText = game.Render();
            Assert.Equal("H I", finalGameText);

        }

        [Fact]
        public void If_user_enters_wrong_character_box_reamins_closed()
        {
            game.Start(ConsoleKey.L);
            game.Start(ConsoleKey.K);
            game.Start(ConsoleKey.C);

            string finalGameText = game.Render();
            Assert.Equal("_ _", finalGameText);
        }

        [Fact]
        public void If_ser_finds_more_than_one_character_in_the_boxes_they_all_opened()
        {
            string text = "ADANA";

            Game localGame = new Game(text);
            localGame.Ready();
            localGame.Start(ConsoleKey.A);

            Assert.Equal("A _ A _ A", localGame.Render());
        }

        [Fact]
        public void All_existing_characters_are_entered_game_over()
        {
            string text = "AAAAA";

            Game localGame = new Game(text);
            localGame.Ready();
            localGame.Start(ConsoleKey.A);

            Assert.True(localGame.GameOverCheck());
        }

        [Fact]
        public void Texts_consisting_of_more_than_one_word_open_correctly()
        {
            string text = "KARABIGA BIGA CANAKKALE";

            Game localGame = new Game(text);
            localGame.Ready();

            Assert.Equal("_ _ _ _ _ _ _ _   _ _ _ _   _ _ _ _ _ _ _ _ _", localGame.Render());
        }

        [Fact]
        public void Character_entered_by_user_opens_correctly_ın_more_than_one_word()
        {
            string text = "KARABIGA CANAKKALE";

            Game localGame = new Game(text);
            localGame.Ready();
            localGame.Start(ConsoleKey.A);

            Assert.Equal("_ A _ A _ _ _ A   _ A _ A _ _ A _ _", localGame.Render());
        }

        [Fact]
        public void If_user_does_not_enter_letter()
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
        public void User_enters_space_when_there_is_more_than_one_word()
        {
            string text = "KARABIGA BIGA CANAKKALE";

            Game localGame = new Game(text);
            localGame.Ready();
            localGame.Start(ConsoleKey.Spacebar);

            Assert.Equal("_ _ _ _ _ _ _ _   _ _ _ _   _ _ _ _ _ _ _ _ _", localGame.Render());
        }

    }
}