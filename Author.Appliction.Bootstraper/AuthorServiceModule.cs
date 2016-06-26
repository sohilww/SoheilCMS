using Authors.Application.Bussiness;
using Authors.Application.BussinessService;
using Ninject.Modules;

namespace Author.Appliction.Bootstraper
{
    public class AuthorServiceModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthorService>().To<AuthorService>();
        }
    }
}