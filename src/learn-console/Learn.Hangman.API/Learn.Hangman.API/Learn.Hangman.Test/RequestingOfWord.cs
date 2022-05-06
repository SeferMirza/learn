using Gazel;
using Gazel.UnitTesting;
using Learn.Hangman.Module.WordManagement;
using Learn.Hangman.Module.WordManagement.Service;
using NUnit.Framework;
using System;
using static Learn.Hangman.Core.Module.Configuration.CoreExceptions;

namespace Learn.Hangman.Test
{
    [TestFixture]
    public class RequestingOfWord : WordManagerTestBase
    {
        [Test]
        public void Given_default_values_are_and_appropriate_word_is_returned__Instead_of_the_ones_that_are_not_given_among_the_requested_parameters()
        {
            var defaultText = "I AM IRONMAN";
            var defaultLevel = 3;
            var defaultLanguage = Language.English;

            var createWord = CreateAWord(defaultText, defaultLevel, defaultLanguage);

            var testing = Context.Get<WordManager>() as IWordManagerService;

            BeginTest();

            var actual = testing.GetWord(3, Language.English);

            Assert.AreEqual(defaultLevel, actual.Level);
        }

        [Test]
        public void When_given_a_level_less_than_min_value_or_greater_than_max_value__Throws_an_exception()
        {
            var testing = Context.Get<WordManager>() as IWordManagerService;

            BeginTest();

            Assert.Throws<LevelShouldBeAtMost>(() => testing.GetWord(4, Language.Turkce), "Given a level greater than max level but didnt throws an exception");
            Assert.Throws<LevelShouldBeAtLeast>(() => testing.GetWord(0, Language.Turkce), "Given a level less than min level but didnt throws an exception");
        }

        [Test]
        public void If_there_are_no_words_in_the_given_parameters__Returns_the_message_not_found()
        {
            Assert.Fail("Kelime olmadığına dair mesaj");
        }
    }
}