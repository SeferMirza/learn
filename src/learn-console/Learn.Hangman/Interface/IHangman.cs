using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Hangman.Interface
{
    public interface IHangman
    {
        string GetWord();
        string GetHangman(int state);
    }
}
