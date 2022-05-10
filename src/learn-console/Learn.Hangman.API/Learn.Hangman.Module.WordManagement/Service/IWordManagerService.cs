namespace Learn.Hangman.Module.WordManagement.Service
{
    public interface IWordManagerService
    {
        IOutWord CreateWord(string text, int level, Language language);
        IOutWord GetRandom(int Level, Language language);
    }
}
