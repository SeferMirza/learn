namespace Learn.Hangman
{
    public class Game
    {
        private char[] challenge;
        private char[] enteredKey;
        private ConsoleKey keyPressed;

        public bool GameOver { get; private set; }

        public Game(string challenge)
        {
            this.challenge = challenge.ToCharArray();

            enteredKey = new char[challenge.Length];
        }

        public void Start(ConsoleKey entry)
        {
            keyPressed = entry;

            for (int i = 0; i < challenge.Length; i++)
            {
                if (challenge[i] == ((char)keyPressed))
                {
                    enteredKey[i] = (char)keyPressed;
                }
            }
        }

        public void Ready()
        {
            for (int i = 0; i < challenge.Length; i++)
            {
                if (challenge[i] == ' ') enteredKey[i] = ' ';
                else enteredKey[i] = '_';
            }
        }

        public bool GameOverCheck()
        {
            GameOver = true;
            for (int j = 0; j < challenge.Length; j++)
            {
                if (enteredKey[j] == '_') GameOver = false;
            }

            return GameOver;
        }

        public string Render()
        {
            return string.Join(' ', enteredKey);
        }
    }
}
