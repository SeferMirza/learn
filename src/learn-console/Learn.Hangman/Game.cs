using Learn.Hangman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Learn.Hangman
{
    public class Game
    {
        char[] word = "HANGMAN".ToCharArray();
        public void Start()
        {
            char[] enteredKey = new char[word.Length];
            for (int i = 0; i < word.Length; i++)
            { 
                enteredKey[i] = '_';
            }
            int failCount = 0;
            bool isGameOver = false;
            while (!isGameOver)
            {
                isGameOver = true;
                Clear();
                WriteLine(String.Join(' ', enteredKey));
                ConsoleKeyInfo keyPressed = ReadKey();
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == ((char)keyPressed.Key))
                    {
                        enteredKey[i] = (char)keyPressed.Key;
                    }
                }
                for (int j = 0; j < word.Length; j++)
                {
                    if (enteredKey[j] == '_')
                    {
                        isGameOver = false;
                    }
                }
            }
            WriteLine("\nHarika tüm harfleri buldunuz!");
        }
    }
}
