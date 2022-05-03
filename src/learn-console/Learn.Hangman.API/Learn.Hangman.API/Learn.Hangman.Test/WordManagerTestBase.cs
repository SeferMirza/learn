using Gazel.UnitTesting;
using Learn.Hangman.Module.WordManagment;

namespace Learn.Hangman.Test
{
    public class WordManagerTestBase : TestBase
    {
        //TODO - Setupsetting değiştirilicek
        public override void SetUp()
        {
            base.SetUp();

            SetUpSetting("Business.MerchantManagement.AssetsUrlFormat", "https://birmasa.blob.core.windows.net/images/merchants/{0}.png");
            SetUpSetting("Business.ProductManagement.AssetsUrlFormat", "https://birmasa.blob.core.windows.net/images/products/{0}.png");
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
