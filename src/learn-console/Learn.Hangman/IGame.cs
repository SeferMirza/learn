﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Hangman
{
    public interface IGame
    {
        GameStatus GetGameStatus();
        void Ready();
        void Start(ConsoleKey key);
        string Render();
        int GetWrongGuessesScore();
    }
}