namespace Learn.DesignPatterns.Creational.AbstractFactory.Components
{
    public interface IButton
    {
        void ConfigText(string text, int fontSize);
        void Click();
    }
}
