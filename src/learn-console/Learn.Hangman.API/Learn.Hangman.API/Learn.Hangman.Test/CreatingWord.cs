using Gazel.UnitTesting;
using Learn.Hangman.Module.WordManagment;
using NUnit.Framework;
using System;

namespace Learn.Hangman.Test
{
    [TestFixture]
    public class CreatingWord:WordManagerTestBase
    {
        [Test]
        public void When_no_parameters_are_given__Then_word_is_created_with_default_values()
        {
            var actual = CreateAWord();

            var expectedLevel = 3;
            var expectedText = "I AM IRONMAN";
            var expectedLanguage = Language.English;

            BeginTest();

            Assert.AreEqual(expectedLevel, actual.Level);
            Assert.AreEqual(expectedLanguage, actual.Language);
            Assert.AreEqual(expectedText, actual.Text);
        }

        [Test]
        public void Given_the_parameters__Then_word_is_created()
        {
            var actual = CreateAWord(
                text:"DEMİRADAM",
                level: 1,
                language: Language.Turkce
                );

            var expectedLevel = 1;
            var expectedText = "DEMİRADAM";
            var expectedLanguage = Language.Turkce;

            Assert.AreEqual(expectedLevel, actual.Level);
            Assert.AreEqual(expectedLanguage, actual.Language);
            Assert.AreEqual(expectedText, actual.Text);
        }

        [Test]
        public void If_the_created_word_already_exists__Throws_an_error()
        {
            //Assert.Fail("TODO - Daha yazılmadı");
            var word = CreateAWord();

            var createWordLevel = 3;
            var createWordText = "I AM IRONMAN";
            var createWordLanguage = Language.English;

            BeginTest();

            Assert.Throws<Exception>(() => CreateAWord(text:createWordText, level:createWordLevel, language:createWordLanguage), "The created word already exists but not throws an error");
        }

        [Test]
        public void When_given_an_undefined_parameter__Throws_an_exception()
        {
            BeginTest();

            Assert.Throws<ArgumentOutOfRangeException>(() => CreateAWord(text:"WORD", level:50, language:Language.English), "Given undefined parameter but didnt throws an exception");
        }
    }
}
