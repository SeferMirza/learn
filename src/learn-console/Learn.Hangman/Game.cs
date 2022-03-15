using static System.Console;

namespace Learn.Hangman
{
    public class Game
    {
        private char[] word;
        private char[] enteredKey;
        private int failCount = 0;
        public bool GameOver { get; set; }
        ConsoleKey keyPressed;

        public Game(string word)
        {
            this.word = word.ToCharArray();
        }

        public void Start(ConsoleKey entry)
        {
            keyPressed = entry;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ((char)keyPressed))
                {
                    enteredKey[i] = (char)keyPressed;
                }
            }
        }

        public void Ready()
        {
            enteredKey = new char[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                enteredKey[i] = '_';
            } 
        }

        public bool IsGameOverCheck()
        {
            GameOver = true;
            for (int j = 0; j < word.Length; j++)
            {
                if (enteredKey[j] == '_')
                {
                    GameOver = false;
                }
            }
            return GameOver;
        }

        public string Render()
        {
            return string.Join(' ', enteredKey);
        }

    }
}

