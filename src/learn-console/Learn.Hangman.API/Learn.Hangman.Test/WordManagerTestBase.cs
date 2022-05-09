using Gazel.UnitTesting;
using Learn.Hangman.Module.WordManagement;

namespace Learn.Hangman.Test
{
    public class WordManagerTestBase : TestBase
    {
        public override void SetUp()
        {
            base.SetUp();
        }

        public override void TearDown()
        {
            base.TearDown();
        }

        protected virtual Word CreateAWord(
            string text = "I AM IRONMAN",
            int level = 3,
            Language language = Language.English
            )
        {
            return Context.Get<WordManager>().CreateWord(
                                                text: text,
                                                level: level,
                                                language: language
                                                );
        }
    }
}
