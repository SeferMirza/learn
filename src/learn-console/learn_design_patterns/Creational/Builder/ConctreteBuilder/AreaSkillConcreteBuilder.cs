using Learn.DesignPatterns.Creational.Builder.Interface;
using Learn.DesignPatterns.Creational.Builder.Product;

namespace Learn.DesignPatterns.Creational.Builder.ConctreteBuilder
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
