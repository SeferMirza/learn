using Gazel;
using Gazel.DataAccess;
using Learn.Hangman.Module.Configuration;
using Learn.Hangman.Module.WordManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;

using static Learn.Hangman.Module.Configuration.WordManagementExceptions;

namespace Learn.Hangman.Module.WordManagement
{
    public class Word : IOutWord
    {
        private readonly IRepository<Word> repository;
        private readonly IModuleContext context;
        private readonly Validator validate;

        protected Word() { }
        public Word(IRepository<Word> repository, IModuleContext context, Validator validate)
        {
            this.repository = repository;
            this.context = context;
            this.validate = validate;
        }

        public virtual int Id { get; protected set; }
        public virtual int Level { get; protected set; }
        public virtual string Text { get; protected set; }
        public virtual Language Language { get; protected set; }

        protected internal virtual Word With(string text, int level, Language language)
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

            repository.Insert(this);

            return this;
        }
    }

    public class Words : Query<Word>
    {
        public Words(IModuleContext context) : base(context) { }

        internal Word SingleByText(string text) => SingleBy(w => w.Text == text);

        internal Word CountBy(int level, Language language) => CountBy(w => w.Level == level && w.Language == language);
        internal Word SingleBy(int level, Language language, int index) => By(skip: index, take: 1, where: w => w.Level == level && w.Language == language).Single();
    }
}
