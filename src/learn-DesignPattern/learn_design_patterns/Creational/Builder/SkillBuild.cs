using learn_DesignPattern.Creational.Builder.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.Builder
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
