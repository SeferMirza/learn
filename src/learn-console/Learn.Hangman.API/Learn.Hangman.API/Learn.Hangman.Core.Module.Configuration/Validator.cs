using Gazel;
using Gazel.Service;
using System;
using System.Collections;
using System.Linq.Expressions;
using static Learn.Hangman.Core.Module.Configuration.CoreExceptions;

namespace Learn.Hangman.Core.Module.Configuration
{
    public class Validator
    {
        private readonly IModuleContext context;

        public Validator(IModuleContext context)
        {
            this.context = context;
        }

        public Validator RequiredText<T>(Expression<Func<T>> parameter)
        {
            var value = ValueOf(parameter);

            if (value is string stringValue)
            {
                if (string.IsNullOrWhiteSpace(stringValue))
                {
                    throw new TextCannotNullOrEmpty();
                }
            }
            else
            {
                if (Equals(value, default(T)))
                {
                    throw new TextCannotNullOrEmpty();
                }
            }

            return this;
        }

        public Validator Between(Expression<Func<int>> parameter, int min = default, int max = default)
        {
            if (min == default) { min = 1; }
            if (max == default) { max = 3; }

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
