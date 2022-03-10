using learn_DesignPattern.Creational.AbstractFactory.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.AbstractFactory.Mobil
{
    public class MobileUIFactory : IUIAbstractFactory
    {
        public IButton Button()
        {
            return new Button();
        }

        public IImage Image()
        {
            return new Image();
        }

        public IText Text()
        {
            return new Text();
        }
    }
}
