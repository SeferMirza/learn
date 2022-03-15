using Learn.DesignPatterns.Creational.Factory.Interface;
using System;

namespace Learn.DesignPatterns.Creational.Factory.Models
{
    class Dostoyevski : IWriter
    {
        public DateTime GetBirthDay()
        {
            return new DateTime(1821, 11, 11);
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
