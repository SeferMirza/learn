using Learn.DesignPatterns.Creational.AbstractFactory.Components;
using System;

namespace Learn.DesignPatterns.Creational.AbstractFactory.Mobil
{
    public class Text : IText
    {
        public void ConfigText(string text, int size)
        {
            Console.WriteLine("Mobile Text text:" + text + "  font size:" + size);
        }
    }
}
