using learn_DesignPattern.Creational.AbstractFactory.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.AbstractFactory
{
    public interface IUIAbstractFactory
    {
        public IButton Button();
        public IImage Image();
        public IText Text();
    }
}
