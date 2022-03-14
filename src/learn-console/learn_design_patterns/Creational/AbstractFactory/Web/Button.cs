using Learn.DesignPatterns.Creational.AbstractFactory.Components;
using System;

namespace Learn.DesignPatterns.Creational.AbstractFactory.Web
{
    class Button : IButton
    {
        public void Click()
        {
            Console.WriteLine("Web button click");
        }

        public void ConfigText(string text, int fontSize)
        {
            Console.WriteLine("WEb Button text:" + text + " fontsize:" + fontSize);
        }
    }
}
