using Ninject;
using Ninject.Modules;
using PluginBase;
using WorkSample.IOC.Bootstrap;
using WorkSamplesPlugin;

namespace PluginManager
{
    public class PluginMager:NinjectModule
    {
        public override void Load()
        {
            Bind<IPluginBase>().To<WorkSamplesPuginBase>();
            Kernel.Load(new WorkSampleDataAccessModule());
        }
    }
}