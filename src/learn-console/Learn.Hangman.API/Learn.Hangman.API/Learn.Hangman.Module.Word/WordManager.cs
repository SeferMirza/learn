using Gazel;
using Learn.Hangman.Module.WordManagement.Service;

namespace Learn.Hangman.Module.WordManagement
{
    public class WordManager : IWordManagerService
    {
        private readonly IModuleContext context;

        public WordManager(IModuleContext context)
        {
            this.context = context;
        }

        public Word CreateWord(string text = default, int level = 3, Language language = Language.English)
        {
            return context.New<Word>().With(text, level, language);
        }

        public Word GetWord(int level = 3, Language language = Language.English)
        {
            return context.Query<Words>().FirstBy(level, language);
        }

        IOutWordM IWordManagerService.GetWord(int Level, Language language) => GetWord(Level, language);
    }
}
