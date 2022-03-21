using Learn.DesignPatterns.Creational.AbstractFactory;
using Learn.DesignPatterns.Creational.AbstractFactory.Web;
using Learn.DesignPatterns.Creational.Builder;
using Learn.DesignPatterns.Creational.Builder.ConctreteBuilder;
using Learn.DesignPatterns.Creational.Builder.Interface;
using Learn.DesignPatterns.Creational.Factory;
using Learn.DesignPatterns.Creational.Factory.Interface;
using Learn.DesignPatterns.Creational.Prototype.Concrete;
using System;

namespace Learn.DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] creational = { "Factory", "Abstract Factory", "Builder", "Prototype" };
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
                        case "Builder":
                            Builder();
                            break;
                        case "Prototype":
                            GameplaySettings gameplaySettings = new GameplaySettings();
                            gameplaySettings.MouseSensitive = 15;
                            var gameplaySettings2 = gameplaySettings.Clone() as GameplaySettings;
                            Console.WriteLine(gameplaySettings2.MouseSensitive);
                            Console.ReadKey(true);
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        static void Builder()
        {
            SkillBuild build = new SkillBuild();
            ISkillBuilder skill;
            Console.WriteLine("Aman Tanrım Düşman Yaklaşıyor Çabuk Bir Saldırı Yap!");
            string[] Skills = { "Holly Shit!", "Aduket", "İmam Power" };
            foreach (var _skill in Skills)
            {
                Console.WriteLine("*" + _skill);
            }
            Console.WriteLine("Lütfen bir saldırı/buff seç:");

            //rLine = Kullanıcıdan saldırı adı alınır.
            string rLine = Console.ReadLine();

            if (rLine == "Holly Shit!")
            {
                skill = new AreaSkillConcreteBuilder();
                build.Build(skill);
                Console.WriteLine("\nBu seferlik kurtulduk :)");
                Console.ReadKey();
            }
            else if (rLine == "Aduket")
            {
                skill = new SingleTargetConcreteBuilder();
                build.Build(skill);
                Console.WriteLine("\nBu seferlik kurtulduk :)");
                Console.ReadKey();
            }
            else if (rLine == "İmam Power")
            {
                skill = new BuffConcreteBuilder();
                build.Build(skill);
                Console.WriteLine("\nHasar Bile Almadık :D");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Geçmiş olsun sözleri yanlış söyledin ve öldün!");
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
