using Learn.DesignPatterns.Creational.Prototype.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.DesignPatterns.Creational.Prototype.Conctrete
{
    enum screenResolution {
        Low,
        Medium,
        High,
        GTX3090
    }
    internal class GraphicSettings : ISettings
    {
        public screenResolution Resolution { get; set; }
        public ISettings Clone()
        {
            return this.MemberwiseClone() as ISettings;
        }
    }
}
