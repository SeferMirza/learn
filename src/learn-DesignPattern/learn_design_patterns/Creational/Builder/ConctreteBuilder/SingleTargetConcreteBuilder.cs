using learn_DesignPattern.Creational.Builder.Interface;
using learn_DesignPattern.Creational.Builder.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.Builder.ConctreteBuilder
{
    class SingleTargetConcreteBuilder : ISkillBuilder
    {
        protected Skill _skill = new Skill();

        public string Fire()
        {
            return "Velehavle veleduket";
        }

        public void StartProcess()
        {
            _skill.BlowUpArea = 2;
            _skill.ManaCost = 5;
            _skill.Name = "Aduket";
            _skill.Range = 100;
            _skill.Power = 500;
        }
    }
}
