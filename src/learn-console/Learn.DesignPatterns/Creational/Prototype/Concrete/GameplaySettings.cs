using Learn.DesignPatterns.Creational.Prototype.Interface;

namespace Learn.DesignPatterns.Creational.Prototype.Concrete
{
    public class GameplaySettings : ISettings
    {
        public int MouseSensitive { get; set; }

        public ISettings Clone()
        {
            return MemberwiseClone() as ISettings;
        }
    }
}
