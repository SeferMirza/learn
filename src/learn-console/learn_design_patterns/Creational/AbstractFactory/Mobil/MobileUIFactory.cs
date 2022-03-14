using Learn.DesignPatterns.Creational.AbstractFactory.Components;

namespace Learn.DesignPatterns.Creational.AbstractFactory.Mobil
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
