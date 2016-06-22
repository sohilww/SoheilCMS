using Ninject.Modules;
using PluginBase;
using WorkSamplesPlugin;

namespace PluginManager
{
    public class PluginMager:NinjectModule
    {
        public override void Load()
        {
            Bind<IPluginBase>().To<WorkSamplesPuginBase>();
        }
    }
}