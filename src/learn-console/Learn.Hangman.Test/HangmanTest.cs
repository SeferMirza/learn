using Learn.Hangman.Texts;
using System;
using Xunit;

namespace Learn.Hangman.Test
{
    public class HangmanTest
    {
        private Game AGame(string challenge,
            int wrongGuessesScore = 5
        )
        {
            var result = new Game(challenge, wrongGuessesScore, new EliteText());

            result.Ready();

            return result;
        }

        [Fact]
        public void Given_a_challenge_one_word__when_user_run_program__then_show_underscores_how_many_the_number_of_characters_in_word()
        {
            var testing = AGame(challenge: "HI");
            var expected = "_ _";

            var actual = testing.Render();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void In_the_challenge__When_user_enters_correct_characters_in_the_boxes__then_all_underscores_are_turn_entered_characters()
        {
            var game = AGame(challenge: "HI");
            var expected = "H I";

            // TODO PAIR put it in setup
            game.Start(ConsoleKey.I);
            game.Start(ConsoleKey.H);
            string actual = game.GetEnteredKey();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Given_challenge__when_the_user_enters_character_which_are_not_in_the_word__then_no_character_pops_up_on_the_boxes()
        {
            var game = AGame(challenge: "HI");
            var expected = "_ _";

            game.Start(ConsoleKey.L);
            game.Start(ConsoleKey.K);
            game.Start(ConsoleKey.C);
            string actual = game.Render();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void If_more_than_one_character_is_in_the_word__when_the_user_enters_the_character__then_each_underscores_are_turn_entered_character()
        {
            var game = AGame(challenge: "ADANA");
            var expected = "A _ A _ A";

            game.Start(ConsoleKey.A);
            var actual = game.Render();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Game_completed__when_all_challenge_completed__then_propertie_returns_false()
        {
            var game = AGame(challenge: "AAAAA");

            game.Start(ConsoleKey.A);
            bool condition = game.GetGameStatus() == GameStatus.Finish ? true : false;

            Assert.True(condition);
        }

        [Fact]
        public void When_the_program_starts_a_challenge_of_over_one_word__all_the_letters_are_rendered_as_underscores()
        {
            var game = AGame(challenge: "KARABIGA BIGA CANAKKALE");
            var expected = "_ _ _ _ _ _ _ _   _ _ _ _   _ _ _ _ _ _ _ _ _";

            var actual = game.Render();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Given_a_challenge_with_more_than_one_word__when_the_user_enters_characters__then_each_underscores_are_turn_entered_character()
        {
            var game = AGame(challenge: "KARABIGA CANAKKALE");
            var expected = "_ A _ A _ _ _ A   _ A _ A _ _ A _ _";

            game.Start(ConsoleKey.A);
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
            var expected = "_ _";

            game.Start(key);
            var actual = game.Render();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Given_a_challenge_with_more_than_one_word__when_user_enters_a_space__then_it_is_ignored()
        {
            // Arrange
            var game = AGame(challenge: "KARABIGA BIGA CANAKKALE");
            var expected = "_ _ _ _ _ _ _ _   _ _ _ _   _ _ _ _ _ _ _ _ _";

            // Act
            game.Start(ConsoleKey.Spacebar);
            var actual = game.Render();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void In_a_challenge_with_text__when_user_wrong_enter_letter__then_the_wrong_GuessesScore_decreases_by_one()
        {
            var game = AGame(challenge: "HI");
            var expected = game.GetWrongGuessesScore() - 1;

            game.Start(ConsoleKey.A);
            var actual = game.GetWrongGuessesScore();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void In_a_challenge_with_text__when_user_maximum_wrong_enter_letter__then_game_over_and_render_information_massage()
        {
            var game = AGame(challenge: "HI", wrongGuessesScore: 1);

            game.Start(ConsoleKey.H);
            game.Start(ConsoleKey.A);

            Assert.True(game.GetGameStatus() == GameStatus.Over);
        }

    }
}
