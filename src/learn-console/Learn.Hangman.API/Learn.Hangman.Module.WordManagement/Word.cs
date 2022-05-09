using Gazel;
using Gazel.DataAccess;
using Learn.Hangman.Core.Module.Configuration;
using Learn.Hangman.Module.WordManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using static Learn.Hangman.Core.Module.Configuration.WordManagementExceptions;

namespace Learn.Hangman.Module.WordManagement
{
    public class Word : IOutWord
    {
        private readonly IRepository<Word> repository;
        private readonly IModuleContext context;
        private readonly Validator validate;

        protected Word() { }
        public Word(IRepository<Word> repository, IModuleContext context, Validator validator)
        {
            this.repository = repository;
            this.context = context;
            this.validate = validator;
        }
        public virtual int Id { get; protected set; }
        public virtual int Level { get; protected set; }
        public virtual string Text { get; protected set; }
        public virtual Language Language { get; protected set; }

        protected internal virtual Word With(string text, int level, Language language)
        {
            Set(text, level, language);
            repository.Insert(this);
            return this;
        }
        protected virtual void Set(string text, int level, Language language)
        {
            validate
                .Limit(() => level, min: 1, max: 3)
                .Required(() => text);

            if (context.Query<Words>().SingleByText(text) != null)
            {
                throw new AlreadyExists($"Already have this '{text}' name word");
            }

            Text = text;
            Level = level;
            Language = language;
        }
    }

    public class Words : Query<Word>
    {
        public Words(IModuleContext context) : base(context) { }

        internal Word SingleByText(string text) => SingleBy(w => w.Text == text);

        internal Word RandomBy(int level, Language language)
        {
            var wordListByLevelAndLang = By(level, language);

            var rand = new Random();
            int skip = rand.Next(0, wordListByLevelAndLang.Count);

            return wordListByLevelAndLang.Skip(skip).Take(1).First();
        }

        private List<Word> By(int level, Language language)
        {
            return By(word => word.Level == level && word.Language == language);
        }
    }
    public enum Language
    {
        Turkce,
        English
    }
}
