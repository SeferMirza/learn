using learn_DesignPattern.Creational.Factory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.Factory.models
{
    class Kafka : IWriter
    {
        public DateTime GetBirthDay()
        {
            return new DateTime(1883,7,3);
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
