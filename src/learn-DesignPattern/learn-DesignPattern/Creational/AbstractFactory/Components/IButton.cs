using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.AbstractFactory.Components
{
    public interface IButton
    {
        void ConfigText(string text,int fontSize);
        void Click();
    }
}
