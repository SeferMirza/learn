using Learn.DesignPatterns.Creational.Builder.Interface;
using Learn.DesignPatterns.Creational.Builder.Product;

namespace Learn.DesignPatterns.Creational.Builder.ConctreteBuilder
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
