using Learn.DesignPatterns.Creational.Prototype.Interface;
using Learn.DesignPatterns.Creational.Prototype.Enums;

namespace Learn.DesignPatterns.Creational.Prototype.Conctrete
{
    internal class GraphicSettings : ISettings
    {
        public screenResolution Resolution { get; set; }
        public ISettings Clone()
        {
            return this.MemberwiseClone() as ISettings;
        }
    }
}
