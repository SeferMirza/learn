using Learn.Hangman.Models;
using Learn.Hangman.Texts;

namespace Learn.Hangman
{
    public class GameFactory
    {
        public Game CreateDefault() =>
            new Game("I AM IRONMAN",
                maxGuessesScore: 4,
                text: new MixedText(
                    new EliteText(),
                    new BloodyText()
                ),
                Man.Animation
            );
    }
}
