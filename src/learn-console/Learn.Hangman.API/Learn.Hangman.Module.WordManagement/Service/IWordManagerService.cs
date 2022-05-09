namespace Learn.Hangman.Module.WordManagement.Service
{
    public interface IWordManagerService
    {
        IOutWord GetRandom(int Level, Language language);
        IOutWord AddWord(string text, int level, Language language);
    }
}
