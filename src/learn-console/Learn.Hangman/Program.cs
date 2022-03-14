using static System.Console;

namespace Learn.Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game("ISTANBUL");
            game.Ready();

            while (!game.isGameOver)
            {
                Clear();
                WriteLine(game.Render());
                game.Start();
                game.Check();
            }

            WriteLine("\nHarika tüm harfleri buldunuz!");
        }
    }
}