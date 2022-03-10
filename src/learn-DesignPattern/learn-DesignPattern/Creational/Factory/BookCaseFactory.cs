using learn_DesignPattern.Creational.Factory.Interface;
using learn_DesignPattern.Creational.Factory.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.Factory
{
    public class BookCaseFactory
    {
        public static IWriter GetWriter(string name)
        {
            IWriter writer = null;
            switch (name)
            {
                case "Dostoyevski":
                    writer = new Dostoyevski();
                    break;
                case "Hawking":
                    writer = new Hawking();
                    break;
                case "Kafka":
                    writer = new Kafka();
                    break;
                case "Sagan":
                    writer = new Sagan();
                    break;
                default:
                    break;
            }
            return writer;
        }
    }
}
