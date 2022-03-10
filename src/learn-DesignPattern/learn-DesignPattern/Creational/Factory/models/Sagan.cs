using learn_DesignPattern.Creational.Factory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.Factory.models
{
    class Sagan : IWriter
    {
        public DateTime GetBirthDay()
        {
            return new DateTime(1934,11,9);
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
