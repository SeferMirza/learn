using Gazel.Service;

namespace Learn.Hangman.Core.Module.Configuration
{
    public class ResultCodes : ResultCodeBlocks
    {
        public static readonly ResultCodeBlock WordManagement = CreateBlock(1, "WordManagement");
    }
}
