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
        public void Given_a_challenge_one_word__when_user_run_program__then_show_as_many_the_number_of_letters_in_word()
        {
            var testing = AGame(challenge: "HI");

            var actual = testing.Render();

            Assert.Equal("_ _", actual);
        }

        [Fact]
        public void In_the_challenge__When_user_enters_correct_characters_in_the_boxes__then_letters_pop_up_in_the_correct_places()
        {
            var game = AGame(challenge: "HI");

            // TODO PAIR put it in setup
            game.Start(ConsoleKey.I);
            game.Start(ConsoleKey.H);

            string finalGameText = game.Render();
            Assert.Equal("H I", finalGameText);

        }

        [Fact]
        public void Given_a_challenge_one_word__when_user_enter_character_that_are_not_in_the_word__then_no_one_character_pop_up_on_boxes()
        {
            var game = AGame(challenge: "HI");

            game.Start(ConsoleKey.L);
            game.Start(ConsoleKey.K);
            game.Start(ConsoleKey.C);

            string finalGameText = game.Render();
            Assert.Equal("_ _", finalGameText);
        }

        [Fact]
        public void Given_a_challenge_more_than_a_character_in_a_word__when_user_enter_this_character__then_opened_this_characters()
        {
            var game = AGame(challenge: "ADANA");

            game.Start(ConsoleKey.A);

            Assert.Equal("A _ A _ A", game.Render());
        }

        [Fact]
        public void Game_over__when_all_challenge_complete__then_propertie_returns_false()
        {
            var game = AGame(challenge: "AAAAA");

            game.Start(ConsoleKey.A);

            Assert.True(game.GameOverCheck());
        }

        [Fact]
        public void Given_a_challenge_more_than_a_word__when_programs_start__then_all_box_correctly_opened()
        {
            var game = AGame(challenge: "KARABIGA BIGA CANAKKALE");

            Assert.Equal("_ _ _ _ _ _ _ _   _ _ _ _   _ _ _ _ _ _ _ _ _", game.Render());
        }

        [Fact]
        public void Given_a_challenge_with_more_than_one_word__when_the_user_enters_characters__then_entered_in_each_word_are_opened()
        {
            var game = AGame(challenge: "KARABIGA CANAKKALE");

            game.Start(ConsoleKey.A);

            Assert.Equal("_ A _ A _ _ _ A   _ A _ A _ _ A _ _", game.Render());
        }

        [Fact]
        public void Given_a_challenge__when_the_user_enters_a_character_that_is_not_in_the_text__then_it_is_ignored()
        {
            var game = AGame(challenge: "HI");

            // TODO REFACTOR to have one hit per test case using test data
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
