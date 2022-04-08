namespace Learn.Hangman
{
    public class Game : IGame
    {
        private readonly int maxGuesses;
        private readonly IText text;
        private readonly string[] countDown;
        private readonly List<Letter> letters;
        private int remainingGuesses;

        public GameStatus GameStatus { get; private set; }

        private bool NoMoreGuesses => remainingGuesses <= 0;

        public Game(string challenge, int maxGuesses, IText text, string[] countDown)
        {
            this.maxGuesses = maxGuesses;
            this.text = text;
            this.countDown = countDown;
            GameStatus = GameStatus.Play;

            letters = challenge.Select(c => new Letter(c)).ToList();
            remainingGuesses = maxGuesses;
        }

        public void ProcessKey(ConsoleKey key)
        {
            var hit = letters
                .Where(l => l.Is(key))
                .ForEach(l => l.Reveal())
                .Any();

            if (!hit) remainingGuesses--;

            GameStatus = NoMoreGuesses
                ? GameStatus.Over
                : letters.All(l => l.Revealed)
                    ? GameStatus.Won
                    : GameStatus.Play;
        }

        public string Render()
        {
            switch (GameStatus)
            {
                case GameStatus.Play:
                    {
                        var yuzde = 1 - (double)remainingGuesses / maxGuesses;
                        var countDownIndex = (int)Math.Round(yuzde * (countDown.Length - 1));

                        return $"{countDown[countDownIndex]}{Environment.NewLine}{string.Join(' ', letters)}";
                    }
                case GameStatus.Won:
                    return text.GameFinishText();
                default:
                    return $"{countDown.Last()}{Environment.NewLine}{text.GameOverText()}";
            }
        }
    }
}
