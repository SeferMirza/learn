namespace Learn.Hangman.MenuOptions
{
    public class Exit : IMenuOptionsEvent
    {
        private readonly IConsole console;

        public Exit(IConsole console)
        {
            this.console = console;
        }
        public string Title => "Exit";

        public void Select()
        {
            console.Exit();
        }
    }
}
