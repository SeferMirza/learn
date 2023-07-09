using Learn.Hangman.Texts;
using System;
using Xunit;

namespace Learn.Hangman.Test
{
    public class HangmanTest
    {
        private Game AGame(
            string challenge = "HI",
            int? maxGuessesScore = default,
            string[]? countDown = default
        )
        {
            if (countDown == null) countDown = new[] { "|-", "|-O" };
            if (maxGuessesScore == null) maxGuessesScore = countDown.Length - 1;

            return new(challenge, maxGuessesScore.Value, new EliteText(), countDown);
        }

        [Fact]
        public void Kullaniciya_bir_kelime_verildiginde__Baslangicta_kelimedeki_harfler_kullaniciya__Altcizgi_olarak_gozukur()
        {
            var testing = AGame(challenge: "HI");
            var expected = "_ _";

            var actual = testing.Render();

            Assert.Contains(expected, actual);
        }

        [Fact]
        public void Kullanici_kelimede_olaman_bir_fark_girdiginde__Hic_bir_altcizgi_harfe_donusmez()
        {
            var game = AGame(challenge: "HI", maxGuessesScore: 5);
            var expected = "_ _";

            game.ProcessKey(ConsoleKey.L);
            game.ProcessKey(ConsoleKey.K);
            game.ProcessKey(ConsoleKey.C);
            string actual = game.Render();

            Assert.Contains(expected, actual);
        }

        [Fact]
        public void Bir_kelimede_ayni_harften_birden_fazla_varken__Kullanici_o_harfi_girdiginde__Harfler_acilir()
        {
            var game = AGame(challenge: "ADANA");
            var expected = "A _ A _ A";

            game.ProcessKey(ConsoleKey.A);
            var actual = game.Render();

            Assert.Contains(expected, actual);
        }

        [Fact]
        public void Ayni_harften_olusan_kelime_verildiginde__Kullanici_dogru_harfi_girerse__Oyun_kazanilir()
        {
            var game = AGame(challenge: "AAAAA");

            game.ProcessKey(ConsoleKey.A);

            Assert.Equal(GameStatus.Won, game.GameStatus);
        }

        [Fact]
        public void Birden_cok_kelimeden_olusan_metin_verildiginde__Butun_harfler_altcizgi_olarak_acilir()
        {
            var game = AGame(challenge: "KARABIGA BIGA CANAKKALE");
            var expected = "_ _ _ _ _ _ _ _   _ _ _ _   _ _ _ _ _ _ _ _ _";

            var actual = game.Render();

            Assert.Contains(expected, actual);
        }

        [Fact]
        public void Kullaniciya_birden_fazla_kelimeden_olusan_metin_verildiginde__Eger_karakterin_girdigi_harf_birden_cok_kelimede_varsa__Butun_kelimelerde_acilir()
        {
            var game = AGame(challenge: "KARABIGA CANAKKALE");
            var expected = "_ A _ A _ _ _ A   _ A _ A _ _ A _ _";

            game.ProcessKey(ConsoleKey.A);
            var actual = game.Render();

            Assert.Contains(expected, actual);
        }

        [InlineData(ConsoleKey.A)]
        [InlineData(ConsoleKey.F1)]
        [InlineData(ConsoleKey.NumPad1)]
        [InlineData(ConsoleKey.Delete)]
        [InlineData(ConsoleKey.Backspace)]
        [InlineData(ConsoleKey.Tab)]
        [InlineData(ConsoleKey.UpArrow)]
        [InlineData(ConsoleKey.Escape)]
        [InlineData(ConsoleKey.Clear)]
        [InlineData(ConsoleKey.D4)]
        [Theory]
        public void Kullanici_kelimede_olamayan_bir_harf_girdiginde__Kelimede_o_harf_acilmaz(ConsoleKey key)
        {
            var game = AGame(challenge: "HI",countDown: new[] { "first", "final" }, maxGuessesScore: 2);
            var expected = "_ _";

            game.ProcessKey(key);
            var actual = game.Render();

            Assert.Contains(expected, actual);
        }

        [Fact]
        public void Metinde_kelimeler_arası_bosluk_yoksayilir__bosluk_karakteri_islevsizdir()
        {
            // Arrange
            var game = AGame(challenge: "KARABIGA BIGA CANAKKALE");
            var expected = "_ _ _ _ _ _ _ _   _ _ _ _   _ _ _ _ _ _ _ _ _";

            // Act
            game.ProcessKey(ConsoleKey.Spacebar);
            var actual = game.Render();

            // Assert
            Assert.Contains(expected, actual);
        }

        [Fact]
        public void Kullanici_yanlis_tahmin_haklarini_bitirdiğinde_oyun_statusu_kaybetme_durumuna_gecer()
        {
            var game = AGame(challenge: "HI", maxGuessesScore: 1);

            game.ProcessKey(ConsoleKey.H);
            game.ProcessKey(ConsoleKey.A);

            Assert.Equal(GameStatus.Over, game.GameStatus);
        }

        [Fact]
        public void Oyun_ilk_basladiginda__ilk_geri_sayim_gorseli_cizilir()
        {
            var game = AGame(countDown: new[] { "first" }, maxGuessesScore: 1);

            var actual = game.Render();

            Assert.Contains("first", actual);
        }

        [Fact]
        public void Kullanici_yanlis_tahmin_yaptiginda__geri_sayim_gorseli_bir_sonraki_adima_gecer()
        {
            var game = AGame(challenge: "HI", countDown: new[] { "first", "second" });
            game.Render();
            game.ProcessKey(ConsoleKey.A);

            var actual = game.Render();

            Assert.Contains($"second", actual);
        }

        [Fact]
        public void Geri_sayim_animasyon_sayisi__Izin_verilen_hata_sayisindan_az_ise__Yuzde_hesabi_ile_ilerlenir()
        {
            var game = AGame(challenge: "HI", countDown: new[] { "first", "second", "third" }, maxGuessesScore: 5);

            game.Render();
            game.ProcessKey(ConsoleKey.A);
            game.ProcessKey(ConsoleKey.A);

            var actual = game.Render();

            Assert.Contains("second", actual);
        }

        [InlineData(0, "1")]
        [InlineData(1, "2")]
        [InlineData(2, "3")]
        [InlineData(3, "4")]
        [InlineData(4, "5")]
        [InlineData(5, "6")]
        [InlineData(6, "7")]
        [InlineData(7, "8")]
        [InlineData(8, "9")]
        [Theory]
        public void Geri_sayim_animasyon_sayisi__Izin_verilen_hata_sayisindan_fazla_ise__Yuzde_hesabi_ile_ilerlenir(int numberOfWrongGuesses, string expectedAnimationStep)
        {
            var game = AGame(challenge: "HI", countDown: new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" }, maxGuessesScore: 8);

            game.Render();
            for(var i = 0;  i < numberOfWrongGuesses; i++)
            {
                game.ProcessKey(ConsoleKey.A);
            }

            var actual = game.Render();

            Assert.Contains(expectedAnimationStep, actual);
        }

        [Fact]
        public void Haklar_tukendiginde__geri_sayim_animasyonunun_final_gorseli_cizilir()
        {
            var game = AGame(challenge: "HI", countDown: new[] { "first", "final" }, maxGuessesScore: 2);

            game.Render();
            game.ProcessKey(ConsoleKey.A);
            game.ProcessKey(ConsoleKey.A);

            var actual = game.Render();

            Assert.Contains("final", actual);
        }

        [Fact]
        public void Geri_sayim_animasyonu_ustte_cizilir()
        {
            var game = AGame(challenge: "HI", countDown: new[] { "first" }, maxGuessesScore: 1);

            var actual = game.Render();

            Assert.StartsWith($"first", actual);

            game.ProcessKey(ConsoleKey.A);
            actual = game.Render();

            Assert.StartsWith($"first", actual);
        }
    }
}
