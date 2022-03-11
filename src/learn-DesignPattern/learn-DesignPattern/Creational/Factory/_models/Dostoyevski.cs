using learn_DesignPattern.Creational.Factory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.Factory.models
{
    class Dostoyevski : IWriter
    {
        public DateTime GetBirthDay()
        {
            return new DateTime(1821,11,11);
        }

        public string GetBooks()
        {
            return "Преступленіе и наказаніе";
        }

        public string GetName()
        {
            return "Fyodor Dostoyevski";
        }
    }
}
