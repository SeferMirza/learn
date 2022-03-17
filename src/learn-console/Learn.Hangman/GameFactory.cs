using Learn.Hangman.Texts;

namespace Learn.Hangman
{
    public class GameFactory
    {
        public Game CreateDefault() =>
            new Game("I AM IRONMAN",
                wrongGuessesScore: 5,
                text: new MixedText(
                    new EliteText(),
                    new BloodyText()
                )
            );
    }
}
