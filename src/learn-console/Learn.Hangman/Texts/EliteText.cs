﻿namespace Learn.Hangman.Texts;

public class EliteText : IText
{
    public string GameFinishText()
    {
        return @"

▄▄▌ ▐ ▄▌▄▄▄ .▄▄▌  ▄▄▌      ·▄▄▄▄         ▐ ▄ ▄▄▄ .    ▄▄▄▄·        ▄· ▄▌
██· █▌▐█▀▄.▀·██•  ██•      ██▪ ██ ▪     •█▌▐█▀▄.▀·    ▐█ ▀█▪▪     ▐█▪██▌
██▪▐█▐▐▌▐▀▀▪▄██▪  ██▪      ▐█· ▐█▌ ▄█▀▄ ▐█▐▐▌▐▀▀▪▄    ▐█▀▀█▄ ▄█▀▄ ▐█▌▐█▪
▐█▌██▐█▌▐█▄▄▌▐█▌▐▌▐█▌▐▌    ██. ██ ▐█▌.▐▌██▐█▌▐█▄▄▌    ██▄▪▐█▐█▌.▐▌ ▐█▀·.
▀▀▀▀ ▀▪ ▀▀▀ .▀▀▀ .▀▀▀     ▀▀▀▀▀•  ▀█▄▀▪▀▀ █▪ ▀▀▀     ·▀▀▀▀  ▀█▄▀▪  ▀ •

";
    }

    public string GameOverText()
    {
        return @"

▄▄ •  ▄▄▄· • ▌ ▄ ·. ▄▄▄ .           ▌ ▐·▄▄▄ .▄▄▄
▐█ ▀ ▪▐█ ▀█ ·██ ▐███▪▀▄.▀·    ▪     ▪█·█▌▀▄.▀·▀▄ █·
▄█ ▀█▄▄█▀▀█ ▐█ ▌▐▌▐█·▐▀▀▪▄     ▄█▀▄ ▐█▐█•▐▀▀▪▄▐▀▀▄
▐█▄▪▐█▐█ ▪▐▌██ ██▌▐█▌▐█▄▄▌    ▐█▌.▐▌ ███ ▐█▄▄▌▐█•█▌
·▀▀▀▀  ▀  ▀ ▀▀  █▪▀▀▀ ▀▀▀      ▀█▄▀▪. ▀   ▀▀▀ .▀  ▀

";
    }
}
