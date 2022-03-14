using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.DesignPatterns.Creational.Prototype.Interface
{
    public interface ISettings
    {
        ISettings Clone();
    }
}
