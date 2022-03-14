using static System.Console;

namespace Learn.Hangman
{
    public class Game
    {
        private char[] word;
        private char[] enteredKey;
        private int failCount = 0;
        public bool isGameOver = false;
        ConsoleKeyInfo keyPressed;

        public Game()
        {
            word = "HANGMAN".ToCharArray();
        }
        public Game(string _word)
        {
            word = _word.ToCharArray();
        }
        public void Start()
        {
            keyPressed = ReadKey();
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ((char)keyPressed.Key))
                {
                    enteredKey[i] = (char)keyPressed.Key;
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

        public bool Check()
        {
            isGameOver = true;
            for (int j = 0; j < word.Length; j++)
            {
                if (enteredKey[j] == '_')
                {
                    isGameOver = false;
                }
            }
            return isGameOver;
        }

        public string Render()
        {
            return String.Join(' ', enteredKey);
        }
    }
}

