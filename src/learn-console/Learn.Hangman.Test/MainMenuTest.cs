using Learn.Hangman.Lists;
using Learn.Hangman.Models;
using System;
using Xunit;

namespace Learn.Hangman.Test
{
    public class MainMenuTest
    {
        private MenuList menuList = new MenuList();
        public IMenu GMenu()
        {
            MainMenu mainMenu = new MainMenu(menuList.GetMainMenu());
            return mainMenu;
        }

        public IMenu MMenu()
        {
            MainMenu mainMenu = new MainMenu(menuList.GetMainMenu());
            return mainMenu;
        }

        public MainMenu Menu()
        {
            MainMenu mainMenu = new MainMenu(menuList.GetMainMenu());
            return mainMenu;
        }

        [Fact]
        public void Oyun_basladiginda_menu_ekrani_yuklenir()
        {
            var menu = GMenu();
            var expect = ">>Play" + Environment.NewLine + "  Exit" + Environment.NewLine;

            Assert.Equal(expect, menu.Render());
        }

        [Fact]
        public void Kullanici_asagi_ok_tusuna_basar_Menude_secili_sekme_bir_alttaki_olur()
        {
            var menu = Menu();
            menu.ProcessKey(ConsoleKey.DownArrow);

            Assert.Equal(1, menu.Position);
        }

        [Fact]
        public void Kullanici_yukarı_ok_tusuna_basar_Menude_secili_sekme_bir_ustteki_olur()
        {
            var menu = Menu();
            menu.ProcessKey(ConsoleKey.UpArrow);

            Assert.Equal(menu.Menus.Count - 1, menu.Position);
        }

        [Fact]
        public void Kullanici_Exit_secenegini_secer_program_sonlanir()
        {
            var menu = Menu();
            menu.ProcessKey(ConsoleKey.UpArrow);
            menu.Select();
        }
    }
}
