namespace Learn.Hangman.Module.WordManagement.Service
{
    public interface IOutWord
    {
        int Id { get; }
        string Text { get; }
        int Level { get; }
        Language Language { get; }
    }
}
