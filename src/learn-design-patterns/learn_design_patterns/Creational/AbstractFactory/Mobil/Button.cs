using Learn.DesignPatterns.Creational.AbstractFactory.Components;
using System;

namespace Learn.DesignPatterns.Creational.AbstractFactory.Mobil
{
    public class Button : IButton
    {
        public void Click()
        {
            Console.WriteLine("Mobile button click");
        }

        public void ConfigText(string text, int fontSize)
        {
            Console.WriteLine("Mobile button text:" + text + " fontsize:" + fontSize);
        }
    }
}
