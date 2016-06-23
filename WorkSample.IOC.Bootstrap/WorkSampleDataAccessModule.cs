using Ninject.Modules;
using WorkSample.Data.DataAccess;
using WorkSamples.Data.DataRepository;
using WorkSamples.DomainModel;

namespace WorkSample.IOC.Bootstrap
{
    public class WorkSampleDataAccessModule:NinjectModule
    {
        public override void Load()
        {
            LoadDbContext();
            Bind<IWorkSampleRepository>().To<WorkSampleRepository>();
            Bind<IWorkCategoryRepository>().To<WorkCategoryRepository>();
        }
        private void LoadDbContext()
        {
            Bind<IWorkSampleUnitofWork>().To<WorkSamplesUnitofWork>()
                .InSingletonScope()
                .WithConstructorArgument("WorkSampleDbContext", new WorkSampleDbContext());

        }
    }
}