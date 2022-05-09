using Gazel;
using Gazel.Service;
using System;
using System.Collections;
using System.Linq.Expressions;
using static Learn.Hangman.Core.Module.Configuration.WordManagementExceptions;

namespace Learn.Hangman.Core.Module.Configuration
{
    public class Validator
    {
        private readonly IModuleContext context;

        public Validator(IModuleContext context)
        {
            this.context = context;
        }

        public Validator RequiredText(string parameter)
        {
            if (string.IsNullOrWhiteSpace(parameter))
            {
                throw new TextCannotNullOrEmpty();
            }

            return this;
        }

        public Validator Between(Expression<Func<int>> parameter, int min = default, int max = default)
        {
            if (min == default) { min = int.MinValue; }
            if (max == default) { max = int.MaxValue; }

            if (max < min) { throw new ArgumentException($"Level cannot be less than {min}", nameof(max)); }

            var value = ValueOf(parameter);

            IsTrue(() => value >= min, () => new LevelShouldBeAtLeast(NameOf(parameter), min));
            IsTrue(() => value <= max, () => new LevelShouldBeAtMost(NameOf(parameter), max));

            return this;
        }

        public Validator IsTrue(Func<bool> validation, Func<ServiceException> exception)
        {
            if (!validation())
            {
                throw exception();
            }

            return this;
        }

        public Validator IsFalse(Func<bool> validation, Func<ServiceException> exception)
        {
            if (validation())
            {
                throw exception();
            }

            return this;
        }

        private T ValueOf<T>(Expression<Func<T>> expression)
        {
            return expression.Compile()();
        }

        private string NameOf<T>(Expression<Func<T>> expression)
        {
            var expressionBody = (MemberExpression)expression.Body;

            return expressionBody.Member.Name;
        }
    }
}
