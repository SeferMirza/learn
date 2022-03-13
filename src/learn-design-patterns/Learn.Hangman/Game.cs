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
        public void Start()
        {
            Man man = new Man();
            User player1 = new User("Ben");
            User player2 = new User("Sen");
            int round = 0;
            int failCount = 0;
            while (true)
            {
                Clear();
                if(round % 2 == 0)
                {
                    //Color option
                    //ForegroundColor = ConsoleColor.Red;
                    //BackgroundColor = ConsoleColor.Green;
                    //ResetColor();

                    WriteLine("-->" + player1.Name + "     " + player2.Name);
                }
                else
                {
                    WriteLine(player1.Name + "     " + "-->" + player2.Name);
                }
                
                WriteLine(man.GetMan(failCount));
                ConsoleKeyInfo keyPressed = ReadKey();
                if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    failCount++;
                }
                round++;
            }
        }
    }
}
