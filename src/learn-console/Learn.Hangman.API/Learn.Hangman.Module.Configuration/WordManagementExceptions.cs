using Gazel.Service;

namespace Learn.Hangman.Module.Configuration
{
    public static class WordManagementExceptions
    {
        public class AlreadyExists : ServiceException
        {
            public AlreadyExists(string wordText)
                : base(ResultCodes.WordManagement.Err(0), wordText) { }
        }

        public class ValueIsRequired : ServiceException
        {
            public ValueIsRequired(string parameterName)
                : base(ResultCodes.WordManagement.Err(1), parameterName) { }
        }

        public class LevelShouldBeAtLeast : ServiceException
        {
            public LevelShouldBeAtLeast(string parameterName, int min)
                : base(ResultCodes.WordManagement.Err(2), parameterName, min) { }
        }

        public class LevelShouldBeAtMost : ServiceException
        {
            public LevelShouldBeAtMost(string parameterName, int max)
                : base(ResultCodes.WordManagement.Err(3), parameterName, max) { }
        }

        public class CannotFind : ServiceException
        {
            public CannotFind()
                : base(ResultCodes.WordManagement.Err(4)) { }
        }
    }
}
