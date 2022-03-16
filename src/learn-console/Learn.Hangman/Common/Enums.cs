using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Hangman.Common
{
    public class Enums
    {
        public enum GameOverType
        {
            Elite,
            Blody
        } 
        public enum FinishGameType
        {
            Elite,
            Blody
        }
        public enum GameStatus
        {
            Play,
            Over,
            Finish
        }
    }
}
