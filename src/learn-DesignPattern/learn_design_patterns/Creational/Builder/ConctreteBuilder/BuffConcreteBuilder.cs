using learn_DesignPattern.Creational.Builder.Interface;
using learn_DesignPattern.Creational.Builder.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.Builder.ConctreteBuilder
{
    class BuffConcreteBuilder : ISkillBuilder
    {
        protected Skill _skill = new Skill();

        public string Fire()
        {
            return "İman Power!";
        }

        public void StartProcess()
        {
            _skill.BlowUpArea = 1;
            _skill.ManaCost = 5;
            _skill.Name = "İmamın Abdest Suyu";
            _skill.Range = 10;
            _skill.Power = 300;
        }
    }
}
