using static System.Console;

namespace Learn.Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game("I AM IRONMAN");
            game.Ready();

            while (!game.GameOver)
            {
                Clear();
                WriteLine(game.Render());
                game.Start(ReadKey().Key);
                game.GameOverCheck();
            }
            
            WriteLine("\nHarika tüm harfleri buldunuz!");
        }
    }
}