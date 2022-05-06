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
    }
}
