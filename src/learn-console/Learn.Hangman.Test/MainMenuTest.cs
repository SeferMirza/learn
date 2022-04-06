using Learn.Hangman.Models;
using System;
using Xunit;

namespace Learn.Hangman.Test
{
    public class MainMenuTest
    {
        public IGame GMenu()
        {
            MainMenu mainMenu = new MainMenu(new string[] {"Play", "Exit"});
            return mainMenu;
        }

        public IMenu MMenu()
        {
            MainMenu mainMenu = new MainMenu(new string[] { "Play", "Exit" });
            return mainMenu;
        }

        public MainMenu Menu()
        {
            MainMenu mainMenu = new MainMenu(new string[] { "Play", "Exit" });
            return mainMenu;
        }

        [Fact]
        public void Oyun_basladiginda_menu_ekrani_yuklenir()
        {
            var menu = GMenu();
            var menus = new Menus();
            var expect = string.Join(Environment.NewLine, menus.MainMenu);

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

            Assert.Equal(menu.Menus.Length - 1, menu.Position);
        }

        [Fact]
        public void Kullanici_Play_secenegini_secer_oyun_baslar()
        {
            var menu = Menu();
            menu.Select();

            Assert.Equal();
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
