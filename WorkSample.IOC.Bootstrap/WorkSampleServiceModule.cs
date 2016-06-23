using Ninject.Modules;
using WorkSample.Application.Bussiness;
using WorkSample.Application.BussinessService;

namespace WorkSample.IOC.Bootstrap
{
    public class WorkSampleServiceModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IWorkCategoryService>().To<WorkCategoryService>();
            Bind<IWorkSampleService>().To<WorkSampleService>();

        }
      
    }
}