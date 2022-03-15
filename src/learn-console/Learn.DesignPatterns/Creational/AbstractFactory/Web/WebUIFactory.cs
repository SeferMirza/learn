using Learn.DesignPatterns.Creational.AbstractFactory.Components;

namespace Learn.DesignPatterns.Creational.AbstractFactory.Web
{
    public class WebUIFactory : IUIAbstractFactory
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
