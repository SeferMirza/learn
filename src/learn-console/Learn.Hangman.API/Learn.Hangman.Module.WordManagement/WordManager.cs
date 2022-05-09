using Gazel;
using Learn.Hangman.Module.Configuration;
using Learn.Hangman.Module.WordManagement.Service;

namespace Learn.Hangman.Module.WordManagement
{
    public class WordManager : IWordManagerService
    {
        private readonly IModuleContext context;
        private readonly Validator validate;

        public WordManager(IModuleContext context, Validator validate)
        {
            this.context = context;
            this.validate = validate;
        }

        public Word CreateWord(string text, int level, Language language) => context.New<Word>().With(text, level, language);

        public Word GetWord(int level = 3, Language language = Language.English)
        {
            validate.Limit(() => level, min: 1, max: 3);

            return context.Query<Words>().RandomBy(level, language);
        }

        #region service mapping
        IOutWord IWordManagerService.GetRandom(int Level, Language language) => GetWord(Level, language);
        IOutWord IWordManagerService.AddWord(string text, int level, Language language) => CreateWord(text, level, language);
        #endregion
    }
}
