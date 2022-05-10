namespace Learn.Hangman.MenuOptions
{
    public class MenuOptionFactory
    {
        public List<IMenuOptionsEvent> FillMainMenuOptions(IConsole console, GameRunner gameRunner)
        {
            List<IMenuOptionsEvent> options = new List<IMenuOptionsEvent>();
            options.Add(new Play(gameRunner));
            options.Add(new Exit(console));
            return options;
        }
    }
}
