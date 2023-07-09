namespace Learn.Hangman.Texts;

public class MixedText : IText
{
    private readonly IText gameFinish;
    private readonly IText gameOver;

    public MixedText(IText gameFinish, IText gameOver) =>
        (this.gameFinish, this.gameOver) = (gameFinish, gameOver);

    public string GameFinishText() => gameFinish.GameFinishText();
    public string GameOverText() => gameOver.GameOverText();
}
