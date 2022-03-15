using Learn.DesignPatterns.Creational.Factory.Interface;
using System;

namespace Learn.DesignPatterns.Creational.Factory.Models
{
    class Hawking : IWriter
    {
        public DateTime GetBirthDay()
        {
            return new DateTime(1942, 1, 8);
        }

        public string GetBooks()
        {
            return "A Brief History of Time";
        }

        public string GetName()
        {
            return "Stephen Hawking";
        }
    }
}
