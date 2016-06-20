using Menu.Data.DataAccess;
using Menu.Data.DataRepository;
using Menu.DomainModel;
using Ninject.Modules;

namespace Menu.IOC.Bootstraper
{
    public class MenuDataAccessBootstraper:NinjectModule
    {
        public override void Load()
        {

            Bind<ISiteMenuRepository>().To<SiteMenuRepository>();
        }
        private void LoadDbContext()
        {
            Bind<IMenuUnitofWork>().To<MenuUnitofWork>()
                .InSingletonScope()
                .WithConstructorArgument("MenuDbContext", new MenuDbContext());

        }
    }
}