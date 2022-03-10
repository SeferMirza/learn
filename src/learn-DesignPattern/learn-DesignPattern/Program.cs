using learn_DesignPattern.Creational.AbstractFactory;
using learn_DesignPattern.Creational.AbstractFactory.Web;
using learn_DesignPattern.Creational.Factory;
using learn_DesignPattern.Creational.Factory.Interface;
using System;

namespace learn_DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] creational = { "Factory", "Abstract Factory", "Builder" };
            while (true)
            {
                while (true)
                {
                    Console.Clear();
                    foreach (var cre in creational)
                    {
                        Console.WriteLine("*" + cre);
                    }
                    Console.WriteLine("Lütfen listeden test etmek istediğiniz bir başlık yazarak enter tuşuna basınız!");
                    string creationalSelect = Console.ReadLine();
                    switch (creationalSelect)
                    {
                        case "Factory":
                            Factory();
                            break;
                        case "Abstract Factory":
                            AbstractFactory();
                            break;
                        default:
                            break;
                    }

                }

            }
        }
        static void AbstractFactory()
        {
            Console.Clear();
            while (true)
            {
                string[] platformList = { "Web", "Mobile" };
                Console.WriteLine("\n*Web\n*Mobile");
                Console.WriteLine("\nListeden platform ismi yazarak enter tuşuna basınız!");
                string platformName = Console.ReadLine();

                if (platformName == "Web")
                {
                    IUIAbstractFactory webFactory = new WebUIFactory();
                    Console.WriteLine("\n*Button\n*Image\n*Text\nLütfen istediğiniz componenet'i yazınız!");
                    string componenetName = Console.ReadLine();
                    if (componenetName == "Button")
                    {
                        var webButton = webFactory.Button();
                        webButton.ConfigText(text: "Button", 20);
                        webButton.Click();
                    }
                    else if (componenetName == "Text")
                    {
                        var webText = webFactory.Text();
                        webText.ConfigText(text: "Text", 20);
                    }
                    else if (componenetName == "Image")
                    {
                        var webImage = webFactory.Image();
                        webImage.ImageUrl(ur: "https:\\google.com");
                        webImage.ShowImage();
                    }
                    else if (componenetName == "Q")
                    {
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (platformName == "Q")
                {
                    break;
                }
                else
                {
                    break;
                }
                Console.WriteLine("Ana menü için 'Q' tuşuna basınız!");
            }
        }


        static void Factory()
        {
            Console.Clear();
            string[] writerList = { "Dostoyvevski", "Hawking", "Kafka", "Sagan" };

            foreach (var wName in writerList)
            {
                Console.WriteLine("*" + wName);
            }

            Console.WriteLine("Lütfen listeden kayıtlı bilgilerine ulaşmak istediğiniz bir yazar ismi yazarak enter tuşuna basınız! Çıkış için 'Q' tuşuna basınız");

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
