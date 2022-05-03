using Castle.MicroKernel;
using Gazel.Configuration;
using Routine.Core.Configuration.Convention;
using Routine.Engine;
using Routine.Engine.Configuration.ConventionBased;
using System.Collections.Generic;
using System.Linq;

namespace Learn.Hangman.App.Service.Extensions
{
    public class DataInterfaceInheritance : ICodingStyleConfiguration
    {
        public void Configure(ConventionBasedCodingStyle codingStyle, IKernel kernel)
        {
            codingStyle
                .Datas.Add(new PropertiesOfInheritedInterfacesConvention())
            ;
        }

        private class PropertiesOfInheritedInterfacesConvention : IConvention<IType, List<IProperty>>
        {
            public bool AppliesTo(IType type)
            {
                return type.Namespace != null && type.Namespace.EndsWith("Service") &&
                    type.IsInterface && !type.Name.EndsWith("Service");
            }

            public List<IProperty> Apply(IType type)
            {
                var result = new List<IProperty>();

                var existingProperties = type.Properties;
                foreach (var @interface in type.AssignableTypes.Where(t => t.IsInterface))
                {
                    var candidates = @interface.Properties as IEnumerable<IProperty>;

                    candidates = candidates.Where(p => !existingProperties.Any(ep => ep.Name == p.Name));
                    candidates = candidates.Where(p => !result.Any(r => r.Name == p.Name));

                    result.AddRange(candidates.Select(p => new ProxyProperty(type, p)));
                }

                return result;
            }
        }

        private class ProxyProperty : IProperty
        {
            private readonly IType proxyType;
            private readonly IProperty real;

            public ProxyProperty(IType proxyType, IProperty real)
            {
                this.proxyType = proxyType;
                this.real = real;
            }

            public bool IsPublic => real.IsPublic;
            public IType ReturnType => real.ReturnType;
            public string Name => real.Name;
            public IType ParentType => proxyType;
            public object[] GetCustomAttributes() => real.GetCustomAttributes();
            public IType GetDeclaringType(bool firstDeclaringType) => real.GetDeclaringType(firstDeclaringType);
            public object[] GetReturnTypeCustomAttributes() => real.GetReturnTypeCustomAttributes();
            public object FetchFrom(object target) => real.FetchFrom(target);
        }
    }
}
