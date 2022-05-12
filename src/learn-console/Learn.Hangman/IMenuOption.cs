using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Hangman
{
    public interface IMenuOption
    {
        string Title { get; }

        void Select();
    }
}
