using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.Factory.Interface
{
    public interface IWriter
    {
        string GetName();
        string GetBooks();
        DateTime GetBirthDay();

    }
}
