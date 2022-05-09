namespace Learn.Hangman.Module.WordManagement.Service
{
    public interface IWordManagerService
    {
        IOutWord GetWord(int Level, Language language);
        IOutWord AddWord(string text, int level, Language language);
    }
}
