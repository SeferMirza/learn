using Gazel.UnitTesting;
using Learn.Hangman.Module.WordManagement;
using Learn.Hangman.Module.WordManagement.Service;

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
            var wm = Context.Get<WordManager>() as IWordManagerService;
            return (Word)wm.CreateWord(text, level, language);
        }
    }
}
