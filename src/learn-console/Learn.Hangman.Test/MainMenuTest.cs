﻿using Moq;
using System;
using Xunit;

namespace Learn.Hangman.Test
{
    public class MainMenuTest : TestBase
    {
        [Fact]
        public void Menu_acildiginda_verilen_seceneklerden_ilk_verilen_secenegi_baslangicta_secili_gosterir()
        {
            var menu = AMenu(
                Play(),
                Exit());

            Assert.Contains("Play", menu.Render());
        }

        [Fact]
        public void Kullanici_ilk_secenek_secili_degilken_sol_ok_tusuna_basar_bir_onceki_secenek_goruntulenir()
        {
            var menu = AMenu(
                Play(),
                Exit());

            menu.Option(AKey(ConsoleKey.RightArrow));
            menu.Option(AKey(ConsoleKey.LeftArrow));

            Assert.Contains("Play", menu.Render());
        }

        [Fact]
        public void Kullanici_ilk_secenek_secili_degiliyken_sol_ok_tusuna_basar_aynı_secenek_secili_kalir()
        {
            var menu = AMenu(
                Play(),
                Exit());

            menu.Option(AKey(ConsoleKey.LeftArrow));

            Assert.Contains("Play", menu.Render());
        }

        [Fact]
        public void Kullanici_sondaki_secenek_secili_degilken_sag_ok_tusuna_basar_sonraki_secenek_goruntulenir()
        {
            var menu = AMenu(
                Play(),
                Exit());

            menu.Option(AKey(ConsoleKey.RightArrow));

            Assert.Contains("Exit", menu.Render());
        }

        [Fact]
        public void Kullanici_sondaki_secenek_seciliyken_sag_ok_tusuna_basar_aynı_secenek_secili_kalir()
        {
            var menu = AMenu(
                Play(),
                Exit());

            menu.Option(AKey(ConsoleKey.RightArrow));

            Assert.Contains("Exit", menu.Render());
        }

        [Fact]
        public void Kullanici_Play_secenegini_secer_secenekteki_action_calisir()
        {
            var game = AGame();
            var menu = AMenu(
                Play(isClickEnter: true),
                Exit());

            menu.Option(AKey(ConsoleKey.Enter));

            Mock.Get(game).Verify(g => g.Render(), Times.AtLeast(1));
        }

        [Fact]
        public void Kullanici_Exit_secenegini_secer_program_sonlanir()
        {
            var exit = Exit(isClickEnter: true);
            var menu = AMenu(
                Play(),
                exit);
            menu.Option(AKey(ConsoleKey.RightArrow));

            menu.Option(AKey(ConsoleKey.Enter));

            Mock.Get(exit).Verify(g => g.Select(), Times.AtLeast(1));
        }
    }
}
