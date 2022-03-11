using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.Builder.Product
{
    public class Skill
    {
        public string Name { get; set; }
        public int ManaCost { get; set; }
        public int Range { get; set; }
        public int BlowUpArea { get; set; }
        public int Power { get; set; }
    }
}
