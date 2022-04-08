using Learn.Hangman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Hangman.Lists
{
    public class MenuList
    {
        private List<Menu> MainMenuList;
        private string[] title;
        public MenuList(string title = "Play, Exit" )
        {
            MainMenuList = new List<Menu>();
            title = title.Replace(" ","");
            this.title = title.Split(",");
        }

        public List<Menu> GetMainMenu()
        {
            for(var index = 0; index < title.Length; index++)
            {
                var menu = new Menu();
                menu.Title = title[index];
                menu.Id = index;
                MainMenuList.Add(menu);
            }
            return MainMenuList;
        }
    }
}
