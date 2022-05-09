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

        public Validator Required<T>(Expression<Func<T>> parameter, string parameterName = null)
        {
            var name = parameterName ?? NameOf(parameter);
            var value = ValueOf(parameter);

            if (value is string stringValue)
            {
                if (string.IsNullOrWhiteSpace(stringValue))
                {
                    throw new ValueIsRequired(name);
                }
            }
            else if (value is IList collection)
            {
                if (collection == null || collection.Count == 0)
                {
                    throw new ValueIsRequired(name);
                }
            }
            else if (value is Array array)
            {
                if (array == null || array.Length == 0)
                {
                    throw new ValueIsRequired(name);
                }
            }
            else
            {
                if (Equals(value, default(T)))
                {
                    throw new ValueIsRequired(name);
                }
            }

            return this;
        }

        public Validator Limit(Expression<Func<int>> parameter, int min = default, int max = default)
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
