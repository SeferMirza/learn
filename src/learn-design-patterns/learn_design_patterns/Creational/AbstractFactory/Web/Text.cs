using Learn.DesignPatterns.Creational.AbstractFactory.Components;
using System;

namespace Learn.DesignPatterns.Creational.AbstractFactory.Web
{
    class Text : IText
    {
        public void ConfigText(string text, int size)
        {
            Console.WriteLine("Web Text text:" + text + " fontsize:" + size);
        }
    }
}
