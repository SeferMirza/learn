using Gazel;
using Learn.Hangman.Core.Module.Configuration;
using Learn.Hangman.Module.WordManagement.Service;

namespace Learn.Hangman.Module.WordManagement
{
    public class WordManager : IWordManagerService
    {
        private readonly IModuleContext context;
        private readonly Validator validator;

        public WordManager(IModuleContext context, Validator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public Word CreateWord(string text, int level = 3, Language language = Language.English)
        {
            return context.New<Word>().With(text, level, language);
        }

        public Word GetWord(int level = 3, Language language = Language.English)
        {
            validator.Between(() => level, min: 1, max: 3);

            return context.Query<Words>().FirstBy(level, language);
        }

        #region service mapping
        IOutWord IWordManagerService.GetWord(int Level, Language language) => GetWord(Level, language);
        #endregion
    }
}
