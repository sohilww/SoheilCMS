using Articles.Data.DataAccess;
using Articles.Data.DataRepository;
using Articles.DomainModel;
using Ninject.Modules;

namespace Articles.IOC.Bootstraper
{
    public class DataAccessModule:NinjectModule
    {
        public override void Load()
        {
            LoadDbContext();

            Bind<IPostRepository>().To<PostRepository>();

            Bind<ICategoryRepository>().To<CategoryRepository>();
        }

        private void LoadDbContext()
        {
            Bind<IArticlesUnitofWork>().To<ArticlesUnitofWork>()
                .WithConstructorArgument("ArticlesDbContext", new ArticlesDbContext());
        }
    }
}