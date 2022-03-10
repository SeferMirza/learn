using learn_DesignPattern.Creational.Factory;
using learn_DesignPattern.Creational.Factory.Interface;
using System;

namespace learn_DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] creational = { "Factory", "abstract_factory", "builder" };
            string[] writerList = { "Dostoyvevski", "Hawking", "Kafka", "Sagan" };
            foreach (var wName in writerList)
            {
                Console.WriteLine("*"+wName);
            }
            Console.WriteLine("Lütfen listeden kayıtlı bilgilerine ulaşmak istediğiniz bir yazar ismi yazarak enter tuşuna basınız!");
            while (true)
            {
                string writerName = Console.ReadLine();
                IWriter writer = BookCaseFactory.GetWriter(writerName);
                if (writer != null)
                {
                    Console.WriteLine("\n////////////////////////\n");
                    Console.WriteLine("Yazar ismi   --> " + writer.GetName() +
                                      "\nDoğum tarihi --> " + writer.GetBirthDay() +
                                      "\nKitapları    --> " + writer.GetBooks());
                    break;
                }
                else
                {
                    Console.WriteLine("\nLütfen listeden kayıtlı bilgilerine ulaşmak istediğiniz bir yazar ismi yazarak enter tuşuna basınız!");
                }
            }
        }
    }
}
