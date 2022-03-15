using static System.Console;

namespace Learn.Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game("ISTANBUL");
            game.Ready();

            while (!game.GameOver)
            {
                Clear();
                WriteLine(game.Render());
                game.Start(ReadKey().Key);
                game.IsGameOverCheck();
            }
            
            WriteLine("\nHarika tüm harfleri buldunuz!");
        }
    }
}