﻿using Gazel;
using Learn.Hangman.Module.Configuration;
using Learn.Hangman.Module.WordManagement.Service;

namespace Learn.Hangman.Module.WordManagement
{
    public class WordManager : IWordManagerService
    {
        private readonly IModuleContext context;
        private readonly ISystem system;
        private readonly Validator validate;

        public WordManager(IModuleContext context, ISystem system, Validator validate)
        {
            this.context = context;
            this.system = system;
            this.validate = validate;
        }

        private Word AddWord(string text, int level, Language language) =>
            context.New<Word>().With(text, level, language);

        private Word GetRandom(int level = 3, Language language = Language.English)
        {
            validate.Limit(() => level, min: 1, max: 3);

            var max = context.Query<Words>().CountBy(level, language);

            var index = system.Random(0, max);

            return context.Query<Words>().SingleBy(level, language, index);
        }

        #region Service Mapping

        IOutWord IWordManagerService.GetRandom(int Level, Language language) => GetRandom(Level, language);
        IOutWord IWordManagerService.AddWord(string text, int level, Language language) => AddWord(text, level, language);

        #endregion
    }
}
