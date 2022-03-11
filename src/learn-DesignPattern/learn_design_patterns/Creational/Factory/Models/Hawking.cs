using learn_DesignPattern.Creational.Factory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.Factory.models
{
    class Hawking : IWriter
    {
        public DateTime GetBirthDay()
        {
            return new DateTime(1942,1,8);
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
