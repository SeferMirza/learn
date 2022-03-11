using learn_DesignPattern.Creational.Builder.Interface;
using learn_DesignPattern.Creational.Builder.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.Builder.ConctreteBuilder
{
    public class AreaSkillConcreteBuilder : ISkillBuilder
    {
        protected Skill _skill = new Skill();

        public string Fire()
        {
            return "Holly Shit! Thats a lot of damage!";
        }

        public void StartProcess()
        {
            _skill.BlowUpArea = 5;
            _skill.ManaCost = 10;
            _skill.Name = "Holly Shit";
            _skill.Range = 3000000;
            _skill.Power = 3500000;
        }
    }
}
