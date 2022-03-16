using static Learn.Hangman.Common.Enums;
using static System.Console;

namespace Learn.Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game("I AM IRONMAN");
            game.Ready();

            while (game.GameStatu == GameStatus.Play)
            {
                Clear();
                game.GetGameStatu();
                WriteLine(game.Render());
                game.Start(ReadKey().Key);
            }

        }
    }
}
