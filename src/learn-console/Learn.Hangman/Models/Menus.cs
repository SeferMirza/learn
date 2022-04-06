using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Hangman.Models
{
    public class Menus
    {
        public string[] MainMenu { get; set; }

        public Menus()
        {
            MainMenu = new string[] {"Play", "Exit" };
        }
    }
}
