namespace Learn.Hangman
{
    public class Game : IGame
    {
        private readonly char[] challenge;
        private readonly int maxGuessesScore;
        private readonly IText text;
        private readonly string[] countDown;
        private readonly char[] enteredKey;
        private int wrongGuessesScore;

        public GameStatus GameStatus { get; private set; }

        public Game(string challenge, int maxGuessesScore, IText text, string[] countDown)
        {
            this.challenge = challenge.ToCharArray();
            this.maxGuessesScore = maxGuessesScore;
            this.text = text;
            this.countDown = countDown;

            enteredKey = new char[challenge.Length];
            wrongGuessesScore = maxGuessesScore;
        }

        public void Start(ConsoleKey keyPressed)
        {
            var isWrongKeyEntry = true;
            if (wrongGuessesScore > 0 && GameStatus == GameStatus.Play)
            {
                for (int i = 0; i < challenge.Length; i++)
                {
                    if (challenge[i] == ((char)keyPressed))
                    {
                        isWrongKeyEntry = false;
                        enteredKey[i] = (char)keyPressed;
                    }
                }

                if (isWrongKeyEntry) wrongGuessesScore--;
            }

            ProcessGameStatus();
        }

        public void Ready()
        {
            for (int i = 0; i < challenge.Length; i++)
            {
                if (challenge[i] == ' ') enteredKey[i] = ' ';
                else enteredKey[i] = '_';
            }
        }

        private void ProcessGameStatus()
        {
            var foundEmptyBox = false;
            if (wrongGuessesScore <= 0 && GameStatus != GameStatus.Finish)
            {
                GameStatus = GameStatus.Over;

                return;
            }

            for (int j = 0; j < challenge.Length; j++)
            {
                if (enteredKey[j] == '_' && wrongGuessesScore > 0)
                {
                    GameStatus = GameStatus.Play;
                    foundEmptyBox = true;
                }
            }

            if (!foundEmptyBox)
            {
                GameStatus = GameStatus.Finish;
            }
        }

        public string Render()
        {
            if (GameStatus == GameStatus.Play)
            {
                var yuzde = 1 - ((double)wrongGuessesScore) / maxGuessesScore;
                var countDownIndex = (int)Math.Round(yuzde * countDown.Length);

                return $"{countDown[countDownIndex]}{Environment.NewLine}{string.Join(' ', enteredKey)}";
            }
            else if (GameStatus == GameStatus.Finish) return text.GameFinishText();
            else return $"{countDown.Last()}{Environment.NewLine}{text.GameOverText()}";
        }

        public int GetWrongGuessesScore() => wrongGuessesScore;

        public string GetEnteredKey() => string.Join(' ', enteredKey);

        public string GetMan() => "";
    }
}
