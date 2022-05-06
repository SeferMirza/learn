using Gazel.Service;

namespace Learn.Hangman.Core.Module.Configuration
{
    public class ResultCodes : ResultCodeBlocks
    {
        public static readonly ResultCodeBlock Core = CreateBlock(1, "Core");
        public static readonly ResultCodeBlock Business = CreateBlock(2, "Business");
    }
}
