using Gazel.Service;

namespace Learn.Hangman.Core.Module.Configuration
{
    public static class CoreExceptions
    {
        public class AlreadyExists : ServiceException
        {
            public AlreadyExists(string wordText)
                : base(ResultCodes.Core.Err(0), wordText) { }
        }

        public class TextCannotNullOrEmpty : ServiceException
        {
            public TextCannotNullOrEmpty()
                : base(ResultCodes.Core.Err(1)) { }
        }

        public class LevelShouldBeAtLeast : ServiceException
        {
            public LevelShouldBeAtLeast(string parameterName, int min)
                : base(ResultCodes.Core.Err(2), parameterName, min) { }
        }

        public class LevelShouldBeAtMost : ServiceException
        {
            public LevelShouldBeAtMost(string parameterName, int max)
                : base(ResultCodes.Core.Err(3), parameterName, max) { }
        }
    }
}
