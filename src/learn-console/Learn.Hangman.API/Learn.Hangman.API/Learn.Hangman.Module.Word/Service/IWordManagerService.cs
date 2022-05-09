namespace Learn.Hangman.Module.WordManagement.Service
{
    public interface IWordManagerService
    {
        IOutWord GetWord(int Level, Language language);
    }
}
