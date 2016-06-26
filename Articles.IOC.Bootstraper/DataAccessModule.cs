using Articles.Data.DataAccess;
using Articles.Data.DataRepository;
using Articles.DomainModel;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Articles.IOC.Bootstraper
{
    public class DataAccessModule:NinjectModule
    {
        public override void Load()
        {
            LoadDbContext();

            Bind<IPostRepository>().To<PostRepository>();

            Bind<ICategoryRepository>().To<CategoryRepository>();

            Bind<ITagRepository>().To<TagRepository>();

            //Todo:Using Ninject Extensions
            //Bind(a=>a.)
            
        }

        private void LoadDbContext()
        {
            Bind<IArticlesUnitofWork>().To<ArticlesUnitofWork>()
                .InRequestScope()
                .WithConstructorArgument("ArticlesDbContext", new ArticlesDbContext());

        }
    }
}