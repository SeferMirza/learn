using Gazel;
using Gazel.UnitTesting;
using Learn.Hangman.Module.WordManagement;
using Learn.Hangman.Module.WordManagement.Service;
using NUnit.Framework;
using System;
using static Learn.Hangman.Module.Configuration.WordManagementExceptions;

namespace Learn.Hangman.Test
{
    [TestFixture]
    public class RequestingOfWord : WordManagerTestBase
    {
        [Test]
        public void Returns_a_random_word__From_records__That_match_the_given_parameters()
        {
            SetUpRandoms(1);

            var createWord = CreateAWord("I AM IRONMAN", 3, Language.English);
            var createWordTwo = CreateAWord("I AM BATMAN", 3, Language.English);

            var testing = Context.Get<WordManager>() as IWordManagerService;

            BeginTest();

            var actual = testing.GetRandom(3, Language.English);

            Assert.AreEqual(3, actual.Level);
            Assert.AreEqual("I AM BATMAN", actual.Text);
            Assert.AreEqual(Language.English, actual.Language);
        }

        [Test]
        public void When_given_a_level_less_than_min_value_or_greater_than_max_value__Throws_an_exception()
        {
            var testing = Context.Get<WordManager>() as IWordManagerService;

            BeginTest();

            Assert.Throws<LevelShouldBeAtMost>(() => testing.GetRandom(4, Language.Turkce), "Given a level greater than max level but didnt throws an exception");
            Assert.Throws<LevelShouldBeAtLeast>(() => testing.GetRandom(0, Language.Turkce), "Given a level less than min level but didnt throws an exception");
        }

        [Test]
        public void If_there_are_no_words_in_the_given_parameters__Returns_the_message_not_found()
        {
            var testing = Context.Get<WordManager>() as IWordManagerService;

            BeginTest();

            Assert.Throws<CannotFindARecord>(() => testing.GetRandom(1, Language.Turkce), "No words find");
        }
    }
}