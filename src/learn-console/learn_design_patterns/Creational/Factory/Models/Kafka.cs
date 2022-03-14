using Learn.DesignPatterns.Creational.Factory.Interface;
using System;

namespace Learn.DesignPatterns.Creational.Factory.Models
{
    class Kafka : IWriter
    {
        public DateTime GetBirthDay()
        {
            return new DateTime(1883, 7, 3);
        }

        public string GetBooks()
        {
            return "briefe an milena";
        }

        public string GetName()
        {
            return "Franz Kafka";
        }
    }
}
