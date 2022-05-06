using Gazel;
using Gazel.UnitTesting;
using Learn.Hangman.Module.WordManagement;
using Learn.Hangman.Module.WordManagement.Service;
using NUnit.Framework;
using System;

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

            var actual = testing.GetWord(3,Language.English);

            Assert.AreEqual(defaultLevel, actual.Level);
        }

        [Test]
        public void When_given_an_undefined_parameter__Throws_an_exception()
        {
            var testing = Context.Get<WordManager>() as IWordManagerService;

            BeginTest();

            Assert.Throws<ArgumentOutOfRangeException>(() => testing.GetWord(50, Language.Turkce), "Given undefined parameter but didnt throws an exception");
        }

        [Test]
        public void If_there_are_no_words_in_the_given_parameters__Returns_the_message_not_found()
        {
            Assert.Fail("Kelime olmadığına dair mesaj");
        }
    }
}