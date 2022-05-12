namespace Learn.Hangman.MenuOptions
{
    public class Play : IMenuOption
    {
        private readonly GameRunner gameRunner;

        public Play(GameRunner gameRunner) => this.gameRunner = gameRunner;

        public string Title => nameof(Play);

        public void Select() => gameRunner.Run();
    }
}
