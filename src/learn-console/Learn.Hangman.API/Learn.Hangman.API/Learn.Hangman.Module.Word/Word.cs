using Gazel;
using Gazel.DataAccess;
using Learn.Hangman.Module.WordManagement.Service;
using System;
using static Learn.Hangman.Core.Module.Configuration.CoreExceptions;

namespace Learn.Hangman.Module.WordManagement
{
    public class Word : IOutWordL
    {
        private readonly IRepository<Word> repository;
        private readonly IModuleContext context;

        protected Word() { }
        public Word(IRepository<Word> repository, IModuleContext context)
        {
            this.repository = repository;
            this.context = context;
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
            if (level > 7)
            {
                throw new ArgumentOutOfRangeException(nameof(level), $"level must be 7 or less.");
            }

            if (text == default)
            {
                throw new TextCannotNullOrEmpty();
            }

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
        public Words(IModuleContext context) : base(context)
        {
        }

        internal Word SingleByText(string text)
        {
            return SingleBy(w => w.Text == text);
        }
        internal Word FirstBy(int level, Language language)
        {
            return FirstBy(w => true,
                optionals: new[]
                {
                    When(level).IsNotDefault().ThenAnd(w => w.Level == level),
                    When(language).IsNotDefault().ThenAnd(w => w.Language == language )
                }
            );
        }
    }
    public enum Language
    {
        Turkce,
        English
    }

}
