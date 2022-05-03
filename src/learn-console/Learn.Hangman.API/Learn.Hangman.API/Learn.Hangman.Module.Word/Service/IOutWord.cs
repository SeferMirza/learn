namespace Learn.Hangman.Module.WordManagment.Service
{
    public interface IOutWordS
    {
        string Text { get; }
    }
    public interface IOutWordM:IOutWordS
    {
        int Level { get; }
    }
    public interface IOutWordL:IOutWordM
    {
        int Id { get; }
        Language Language { get; }
    }
}
