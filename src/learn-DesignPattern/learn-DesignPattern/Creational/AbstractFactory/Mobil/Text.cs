using learn_DesignPattern.Creational.AbstractFactory.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.AbstractFactory.Mobil
{
    public class Text : IText
    {
        public void ConfigText(string text, int size)
        {
            Console.WriteLine("Mobile Text text:"+text+"  font size:"+size);
        }
    }
}
