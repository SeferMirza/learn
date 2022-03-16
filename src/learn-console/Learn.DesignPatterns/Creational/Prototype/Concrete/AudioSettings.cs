using Learn.DesignPatterns.Creational.Prototype.Interface;

namespace Learn.DesignPatterns.Creational.Prototype.Concrete
{
    public class AudioSettings : ISettings
    {
        public int MusicVolume { get; set; }

        public ISettings Clone()
        {
            return MemberwiseClone() as ISettings;
        }
    }
}
