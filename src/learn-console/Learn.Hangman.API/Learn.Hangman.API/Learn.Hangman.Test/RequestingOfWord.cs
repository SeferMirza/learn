using Gazel;
using Gazel.UnitTesting;
using Learn.Hangman.Module.WordManagment;
using NUnit.Framework;

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

            var testing = Context.Get<WordManager>();

            BeginTest();

            var actual = testing.GetWord();

            Assert.AreEqual(defaultLevel, actual.Level);
            Assert.AreEqual(defaultLanguage, actual.Language);
        }

        [Test]
        public void When_the_defined_parameter_is_given_but_there_is_no_word__Then_closest_word_is_returned()
        {
            Assert.Fail("TODO - Daha yazılmadı");
        }
    }
}
