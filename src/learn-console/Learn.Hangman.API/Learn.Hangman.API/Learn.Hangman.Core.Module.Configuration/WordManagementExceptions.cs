using Gazel.Service;

namespace Learn.Hangman.Core.Module.Configuration
{
    public static class WordManagementExceptions
    {
        public class AlreadyExists : ServiceException
        {
            public AlreadyExists(string wordText)
                : base(ResultCodes.WordManagement.Err(0), wordText) { }
        }

        public class TextCannotNullOrEmpty : ServiceException
        {
            public TextCannotNullOrEmpty()
                : base(ResultCodes.WordManagement.Err(1)) { }
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
    }
}
