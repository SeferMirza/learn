namespace Learn.Hangman.MenuOptions
{
    public class Play : IMenuOptionsEvent
    {
        private readonly GameRunner gameRunner;

        public Play(GameRunner gameRunner)
        {
            this.gameRunner = gameRunner;
        }
        public string Title => "Play";

        public void Select()
        {
            gameRunner.Run();
        }
    }
}
