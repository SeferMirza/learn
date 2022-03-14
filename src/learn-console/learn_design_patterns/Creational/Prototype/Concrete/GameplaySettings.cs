using Learn.DesignPatterns.Creational.Prototype.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
