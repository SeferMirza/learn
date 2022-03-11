using learn_DesignPattern.Creational.AbstractFactory.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.AbstractFactory.Web
{
    class Button : IButton
    {
        public void Click()
        {
            Console.WriteLine("Web button click");
        }

        public void ConfigText(string text, int fontSize)
        {
            Console.WriteLine("WEb Button text:"+text+" fontsize:"+fontSize);
        }
    }
}
