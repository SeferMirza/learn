using System;
using Xunit;

namespace Learn.Hangman.Test
{
    // TODO REFACTOR rename all tests to fit in AAA or Given When Then format
    public class HangmanTest
    {
        private Game AGame(string challenge)
        {
            var result = new Game(challenge);

            result.Ready();

            return result;
        }

        [Fact]
        public void Given_a_challenge_one_word__when_user_run_program__then_show_how_many_the_number_of_characters_in_word()
        {
            var testing = AGame(challenge: "HI");

            var actual = testing.Render();
            var expected = "_ _";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void In_the_challenge__When_user_enters_correct_characters_in_the_boxes__then_letters_pop_up_in_the_correct_places()
        {
            var game = AGame(challenge: "HI");

            // TODO PAIR put it in setup
            game.Start(ConsoleKey.I);
            game.Start(ConsoleKey.H);

            string actual = game.Render();
            var expected = "H I";

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Given_challenge__when_the_user_enters_character_which_are_not_in_the_word__then_no_character_pops_up_on_the_boxes()
        {
            var game = AGame(challenge: "HI");

            game.Start(ConsoleKey.L);
            game.Start(ConsoleKey.K);
            game.Start(ConsoleKey.C);

            string actual = game.Render();
            var expected = "_ _";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void If_more_than_one_character_is_in_the_word__when_the_user_enters_the_character__then_all_characters_opened()
        {
            var game = AGame(challenge: "ADANA");

            game.Start(ConsoleKey.A);

            var actual = game.Render();
            var expected = "A _ A _ A";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Game_complated__when_all_challenge_completed__then_propertie_returns_false()
        {
            var game = AGame(challenge: "AAAAA");

            game.Start(ConsoleKey.A);

            bool condition = game.GameOverCheck();

            Assert.True(condition);
        }

        [Fact]
        public void When_the_program_starts_a_challenge_of_over_one_word__then_all_the_boxes_open_properly()
        {
            var game = AGame(challenge: "KARABIGA BIGA CANAKKALE");

            var expected = "_ _ _ _ _ _ _ _   _ _ _ _   _ _ _ _ _ _ _ _ _";
            var actual = game.Render();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Given_a_challenge_with_more_than_one_word__when_the_user_enters_characters__then_entered_each_character_are_opened()
        {
            var game = AGame(challenge: "KARABIGA CANAKKALE");

            game.Start(ConsoleKey.A);

            var expected = "_ A _ A _ _ _ A   _ A _ A _ _ A _ _";
            var actual = game.Render();

            Assert.Equal(expected, actual);
        }

        [InlineData(ConsoleKey.A)]
        [InlineData(ConsoleKey.F1)]
        [InlineData(ConsoleKey.NumPad1)]
        [InlineData(ConsoleKey.Delete)]
        [InlineData(ConsoleKey.Backspace)]
        [InlineData(ConsoleKey.Tab)]
        [InlineData(ConsoleKey.UpArrow)]
        [InlineData(ConsoleKey.Escape)]
        [InlineData(ConsoleKey.Clear)]
        [InlineData(ConsoleKey.D4)]
        [Theory]
        public void When_the_user_enters_a_character_that_is_not_in_the_text__then_it_is_ignored(ConsoleKey key)
        {
            var game = AGame(challenge: "HI");

            // TODO REFACTOR to have one hit per test case using test data
            game.Start(key);

            var expected = "_ _";
            var actual = game.Render();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Given_a_challenge_with_more_than_one_word__when_user_enters_a_space__then_it_is_ignored()
        {
            // Arrange
            var game = AGame(challenge: "KARABIGA BIGA CANAKKALE");

            // Act
            game.Start(ConsoleKey.Spacebar);

            var expected = "_ _ _ _ _ _ _ _   _ _ _ _   _ _ _ _ _ _ _ _ _";
            var actual = game.Render();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
