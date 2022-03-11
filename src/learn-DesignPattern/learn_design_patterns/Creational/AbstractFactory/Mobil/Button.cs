using learn_DesignPattern.Creational.AbstractFactory.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.AbstractFactory.Mobil
{
    public class Button : IButton
    {
        public void Click()
        {
            Console.WriteLine("Mobile button click");
        }

        public void ConfigText(string text, int fontSize)
        {
            Console.WriteLine("Mobile button text:"+text+" fontsize:"+fontSize);
        }
    }
}
