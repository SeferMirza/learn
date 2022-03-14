using Learn.DesignPatterns.Creational.Builder.Interface;
using Learn.DesignPatterns.Creational.Builder.Product;

namespace Learn.DesignPatterns.Creational.Builder.ConctreteBuilder
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
