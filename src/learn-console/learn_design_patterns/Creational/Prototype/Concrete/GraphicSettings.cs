using Learn.DesignPatterns.Creational.Prototype.Interface;
using Learn.DesignPatterns.Creational.Prototype.Enums;

namespace Learn.DesignPatterns.Creational.Prototype.Concrete
{
    public class GraphicSettings : ISettings
    {
        public screenResolution Resolution { get; set; }

        public ISettings Clone()
        {
            return MemberwiseClone() as ISettings;
        }
    }
}
