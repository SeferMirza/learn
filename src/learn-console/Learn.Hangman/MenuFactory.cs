using Learn.Hangman.MenuOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Hangman
{
    public class MenuFactory
    {
        public MainMenu CreateDefaultMainMenu()
        {
            List<IMenuOptionsEvent> menus = new List<IMenuOptionsEvent>();
            menus.Add(new Play());
            menus.Add(new Exit());
            return new MainMenu(menus);
        }
    }
}
