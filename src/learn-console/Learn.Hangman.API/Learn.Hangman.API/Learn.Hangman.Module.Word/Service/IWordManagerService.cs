namespace Learn.Hangman.Module.WordManagement.Service
{
    public interface IWordManagerService
    {
        IOutWordM GetWord(int Level, Language language);
    }
}
