using Learn.DesignPatterns.Creational.Factory.Interface;
using Learn.DesignPatterns.Creational.Factory.Models;

namespace Learn.DesignPatterns.Creational.Factory
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
