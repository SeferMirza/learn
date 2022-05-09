﻿using Gazel.UnitTesting;
using Learn.Hangman.Module.WordManagement;
using NUnit.Framework;
using System;
using static Learn.Hangman.Core.Module.Configuration.WordManagementExceptions;

namespace Learn.Hangman.Test
{
    [TestFixture]
    public class CreatingWord : WordManagerTestBase
    {
        [Test]
        public void When_creating_a_new_word__Text_is_null_or_empty__Then_it_throws_an_error()
        {
            var testing = Context.Get<WordManager>();

            BeginTest();

            Assert.Throws<TextCannotNullOrEmpty>(() => testing.CreateWord(text:" "));
            Assert.Throws<TextCannotNullOrEmpty>(() => testing.CreateWord(text:""));
        }

        [Test]
        public void When_no_parameters_are_given_except_text__Then_word_is_created_with_default_values()
        {
            var testing = Context.Get<WordManager>();

            var expectedLevel = 3;
            var expectedLanguage = Language.English;
            var expectedText = "I AM IRONMAN";

            BeginTest();

            var actual = testing.CreateWord(
                text: "I AM IRONMAN"
                );

            Verify.ObjectIsPersisted(actual);

            Assert.AreEqual(expectedLevel, actual.Level);
            Assert.AreEqual(expectedLanguage, actual.Language);
            Assert.AreEqual(expectedText, actual.Text);
        }

        [Test]
        public void Given_the_parameters__Then_word_is_created()
        {
            var expectedLevel = 1;
            var expectedText = "DEMİRADAM";
            var expectedLanguage = Language.Turkce;

            var testing = Context.Get<WordManager>();

            BeginTest();

            var actual = testing.CreateWord(
                text: "DEMİRADAM",
                level: 1,
                language: Language.Turkce
                );

            Verify.ObjectIsPersisted(actual);

            Assert.AreEqual(expectedLevel, actual.Level);
            Assert.AreEqual(expectedLanguage, actual.Language);
            Assert.AreEqual(expectedText, actual.Text);
        }

        [Test]
        public void If_the_created_word_already_exists__Throws_an_error()
        {
            var word = CreateAWord();

            var createWordLevel = 3;
            var createWordText = "I AM IRONMAN";
            var createWordLanguage = Language.English;

            var testing = Context.Get<WordManager>();

            BeginTest();

            Assert.Throws<AlreadyExists>(() => testing.CreateWord(text: createWordText, level: createWordLevel, language: createWordLanguage), "The created word already exists but not throws an error");
        }

        [Test]
        public void When_given_a_level_less_than_min_value_or_greater_than_max_value__Throws_an_exception()
        {
            var testing = Context.Get<WordManager>();

            BeginTest();

            Assert.Throws<LevelShouldBeAtMost>(() => testing.CreateWord(text: "WORD", level: 4, language: Language.English), "Given a level greater than max level but didnt throws an exception");
            Assert.Throws<LevelShouldBeAtLeast>(() => testing.CreateWord(text: "WORD", level: 0, language: Language.English), "Given a level less than min level but didnt throws an exception");
        }
    }
}
