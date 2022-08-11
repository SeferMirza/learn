using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Learn.Hangman.Test
{
    public class EndMenuTest : TestBase
    {
        [Fact]
        public void Menuler_parantez_icinde_menu_basliginin_bas_harfi_ile_menu_basligi_listelenir()
        {
            var endMenu = AEndMenu( 
                Play(),
                Exit());
            var actual = endMenu.Render();
            var expected = "Play['P'], Exit['E']";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Listelenen_menulerin_bas_harfine_basildiginda_basilan_menu_calistirilir()
        {
            var menuOption = Exit();
            var endMenu = AEndMenu(
                menuOption);

            endMenu.Option(AKey(ConsoleKey.E));

            Mock.Get(menuOption).Verify(m => m.Select(), Times.Once());
        }
    }
}
