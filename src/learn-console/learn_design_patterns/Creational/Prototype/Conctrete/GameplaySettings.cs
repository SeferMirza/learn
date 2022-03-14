using Learn.DesignPatterns.Creational.Prototype.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.DesignPatterns.Creational.Prototype.Conctrete
{
    internal class GameplaySettings : ISettings
    {
        public int MouseSensitive { get; set; }
        public ISettings settings()
        {
            return this.MemberwiseClone() as ISettings;
        }
    }
}
