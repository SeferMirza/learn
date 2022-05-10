using Castle.MicroKernel;
using Gazel.Configuration;
using Learn.Hangman.Module.WordManagement.Service;
using Routine;
using Routine.Engine.Configuration.ConventionBased;

namespace Learn.Hangman.App.Service
{
    public class WordApi : ICodingStyleConfiguration
    {
        public void Configure(ConventionBasedCodingStyle codingStyle, IKernel kernel)
        {
            codingStyle.AddTypes(c => c.WebService("Word", t => t
                .Methods.Add(m => m.Proxy<IWordManagerService>().TargetBySingleton(kernel))
            ));
        }
    }
}
