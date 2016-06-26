using Authors.Data.DataAccess;
using Authors.Data.DataRepository;
using Authors.DomainModel;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Author.Appliction.Bootstraper
{
    public class AuthorDataAccessModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IAuthorUnitofWork>().To<AuthorUnitofWork>();
            Bind<IAuthorRepository>().To<AuthorRepository>();
        }
        private void LoadDbContext()
        {
            Bind<IAuthorUnitofWork>().To<AuthorUnitofWork>()
                .InRequestScope()
                .WithConstructorArgument("MenuDbContext", new AuthorDbContext());

        }

    }
}