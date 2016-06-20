using Menu.Application.Bussiness;
using Menu.Application.BussinessService;
using Ninject.Modules;

namespace Menu.IOC.Bootstraper
{
    public class MenuServiceBootstraper:NinjectModule
    {
        public override void Load()
        {
            Bind<ISiteMenuService>().To<SiteMenuService>();
        }
    }
}