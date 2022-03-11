using learn_DesignPattern.Creational.Builder.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_DesignPattern.Creational.Builder.Interface
{
    public interface ISkillBuilder
    {
        void StartProcess();
        string Fire();
    }
}
