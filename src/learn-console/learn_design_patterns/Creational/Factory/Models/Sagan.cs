using Learn.DesignPatterns.Creational.Factory.Interface;
using System;

namespace Learn.DesignPatterns.Creational.Factory.Models
{
    class Sagan : IWriter
    {
        public DateTime GetBirthDay()
        {
            return new DateTime(1934, 11, 9);
        }

        public string GetBooks()
        {
            return "Cosmos";
        }

        public string GetName()
        {
            return "Carl Sagan";
        }
    }
}
