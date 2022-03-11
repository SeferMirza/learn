using Learn.DesignPatterns.Creational.Builder.Interface;
using System;

namespace Learn.DesignPatterns.Creational.Builder
{
    public class SkillBuild
    {
        public void Build(ISkillBuilder builder)
        {
            builder.StartProcess();
            Console.WriteLine(builder.Fire());
        }
    }
}
