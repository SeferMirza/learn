using Gazel;
using System;

namespace Learn.Hangman.Module.WordManagment
{
    public class WordManager
    {
        private readonly IModuleContext context;

        public WordManager(IModuleContext context)
        {
            this.context = context;
        }

        public Word CreateWord(string text = "I AM IRONMAN", int level = 3, Language language = Language.English)
        {
            return context.New<Word>().With(text, level, language);
        }

        public Word GetWord(int level = 3, Language language = Language.English)
        {
            return context.Query<Words>().FirstBy(level, language);
        }
    }
}
