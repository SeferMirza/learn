using Learn.Hangman.Interface;
using Learn.Hangman.Models;
using static Learn.Hangman.Common.Enums;

namespace Learn.Hangman
{
    public class Game
    {
        private char[] challenge;
        private char[] enteredKey;
        private ConsoleKey keyPressed;
        private byte wrongGuessesScore = 5;
        private IText GameEndText;
        public GameStatus GameStatus { get; private set; }

        public Game(string challenge)
        {
            this.challenge = challenge.ToCharArray();

            enteredKey = new char[challenge.Length];
        }

        public void Start(ConsoleKey entry)
        {
            var isWrongKeyEntry = true;
            keyPressed = entry;
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
            GetGameStatus();
        }

        public void Ready()
        {
            for (int i = 0; i < challenge.Length; i++)
            {
                if (challenge[i] == ' ') enteredKey[i] = ' ';
                else enteredKey[i] = '_';
            }
        }

        public GameStatus GetGameStatus()
        {
            bool foundEmptyBox = false;

            if (wrongGuessesScore <= 0 && GameStatus != GameStatus.Finish)
            {
                GameStatus = GameStatus.Over;
                return GameStatus;
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

            return GameStatus;
        }

        public string Render()
        {
            if (GameStatus == GameStatus.Play)
            {
                return string.Join(' ', enteredKey);
            }
            else if (GameStatus == GameStatus.Finish)
            {
                GameEndText = new EliteTexts(); 
                return GameEndText.GameFinishText();
            }
            else
            {
                GameEndText = new BloodyTexts();
                return GameEndText.GameOverText();
            }
        }

        public byte GetWrongGuessesScore()
        {
            return wrongGuessesScore;
        }

        public string GetEnteredKey()
        {
            return string.Join(' ', enteredKey);
        }
    }
}
