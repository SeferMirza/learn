using Learn.DesignPatterns.Creational.AbstractFactory.Components;

namespace Learn.DesignPatterns.Creational.AbstractFactory
{
    public interface IUIAbstractFactory
    {
        public IButton Button();
        public IImage Image();
        public IText Text();
    }
}
