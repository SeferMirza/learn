﻿using Learn.DesignPatterns.Creational.Prototype.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.DesignPatterns.Creational.Prototype.Conctrete
{
    internal class AudioSettings : ISettings
    {
        public int MusicVolume { get; set; }
        public ISettings Clone()
        {
            return this.MemberwiseClone() as ISettings;
        }
    }
}
