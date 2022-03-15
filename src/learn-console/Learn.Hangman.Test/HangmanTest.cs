using System;
using Xunit;

namespace Learn.Hangman.Test
{
    // TODO rename all tests to fit in AAA or Given When Then format
    public class HangmanTest
    {
        private Game AGame(string challenge = "HI")
        {
            var result = new Game(challenge);

            result.Ready();

            return result;
        }

        [Fact]
        public void Game_initial_state_control()
        {
            var game = AGame();

            string text = "_ _"; // empty text

            Assert.Equal(text, game.Render());
        }

        [Fact]
        public void If_user_enter_right_character_open_all_box()
        {
            var game = AGame();

            game.Start(ConsoleKey.I);
            game.Start(ConsoleKey.H);

            string finalGameText = game.Render();
            Assert.Equal("H I", finalGameText);

        }

        [Fact]
        public void If_user_enters_wrong_character_box_reamins_closed()
        {
            var game = AGame();

            game.Start(ConsoleKey.L);
            game.Start(ConsoleKey.K);
            game.Start(ConsoleKey.C);

            string finalGameText = game.Render();
            Assert.Equal("_ _", finalGameText);
        }

        [Fact]
        public void If_user_finds_more_than_one_character_in_the_boxes_they_all_opened()
        {
            var game = AGame(challenge: "ADANA");

            game.Start(ConsoleKey.A);

            Assert.Equal("A _ A _ A", game.Render());
        }

        [Fact]
        public void All_existing_characters_are_entered_game_over()
        {
            var game = AGame(challenge: "AAAAA");

            game.Start(ConsoleKey.A);

            Assert.True(game.GameOverCheck());
        }

        [Fact]
        public void Texts_consisting_of_more_than_one_word_open_correctly()
        {
            var game = AGame(challenge: "KARABIGA BIGA CANAKKALE");

            Assert.Equal("_ _ _ _ _ _ _ _   _ _ _ _   _ _ _ _ _ _ _ _ _", game.Render());
        }

        [Fact]
        public void Character_entered_by_user_opens_correctly_ın_more_than_one_word()
        {
            var game = AGame(challenge: "KARABIGA CANAKKALE");

            game.Start(ConsoleKey.A);

            Assert.Equal("_ A _ A _ _ _ A   _ A _ A _ _ A _ _", game.Render());
        }

        [Fact]
        public void If_user_does_not_enter_letter()
        {
            var game = AGame();

            // TODO Refactor to have one hit per test case using test data
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
        public void Given_a_challenge_with_more_than_one_word__when_user_enters_a_space__then_it_is_ignored()
        {
            // Arrange
            var game = AGame(challenge: "KARABIGA BIGA CANAKKALE");

            // Act
            game.Start(ConsoleKey.Spacebar);

            // Assert
            Assert.Equal("_ _ _ _ _ _ _ _   _ _ _ _   _ _ _ _ _ _ _ _ _", game.Render());
        }
    }
}
