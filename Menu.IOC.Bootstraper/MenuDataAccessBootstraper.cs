using Menu.Data.DataAccess;
using Menu.Data.DataRepository;
using Menu.DomainModel;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Menu.IOC.Bootstraper
{
    public class MenuDataAccessBootstraper:NinjectModule
    {
        public override void Load()
        {
            Bind<IMenuUnitofWork>().To<MenuUnitofWork>();
            Bind<ISiteMenuRepository>().To<SiteMenuRepository>();
        }
        private void LoadDbContext()
        {
            Bind<IMenuUnitofWork>().To<MenuUnitofWork>()
                .InRequestScope()
                .WithConstructorArgument("MenuDbContext", new MenuDbContext());

        }
    }
}