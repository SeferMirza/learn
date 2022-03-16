using Learn.Hangman.Models;
using static Learn.Hangman.Common.Enums;

namespace Learn.Hangman
{
    public class Game
    {
        private char[] challenge;
        private char[] enteredKey;
        private ConsoleKey keyPressed;
        private byte wrongGuessesScore = 6;
        private GameTexts gameTexts;
        public GameStatus GameStatu { get; private set; }

        public Game(string challenge)
        {
            this.challenge = challenge.ToCharArray();

            enteredKey = new char[challenge.Length];

            gameTexts = new GameTexts();
        }

        public void Start(ConsoleKey entry)
        {
            var isWrongKeyEntry = true;
            keyPressed = entry;

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

        public void Ready()
        {
            for (int i = 0; i < challenge.Length; i++)
            {
                if (challenge[i] == ' ') enteredKey[i] = ' ';
                else enteredKey[i] = '_';
            }
        }

        public GameStatus GetGameStatu()
        {
            bool foundEmptyBox = false;

            if (wrongGuessesScore <= 0)
            {
                GameStatu = GameStatus.Over;
                return GameStatu;
            }

            for (int j = 0; j < challenge.Length; j++)
            {
                if (enteredKey[j] == '_')
                {
                    GameStatu = GameStatus.Play;
                    foundEmptyBox = true;
                }
            }
            if (!foundEmptyBox)
            {
                GameStatu = GameStatus.Finish;
            }

            return GameStatu;
        }

        public string Render()
        {
            if (GameStatu == GameStatus.Play)
            {
                return string.Join(' ', enteredKey);
            }
            else if (GameStatu == GameStatus.Finish)
            {
                return gameTexts.GetFinishGameText(FinishGameType.Elite);
            }
            else
            {
                return gameTexts.GetGameOverText(GameOverType.Elite);
            }
        }

        public byte GetWrongGuessesScroce()
        {
            return wrongGuessesScore;
        }
    }
}
