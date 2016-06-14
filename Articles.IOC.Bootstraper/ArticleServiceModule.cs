using Articles.Application.Bussiness;
using Articles.Application.BussinessService;
using Articles.Data.DataAccess;
using Articles.Data.DataRepository;
using Articles.DomainModel;
using Ninject.Modules;
using Ninject.Extensions.Conventions;
namespace Articles.IOC.Bootstraper
{
    public class ArticleServiceModule:NinjectModule
    {
        public override void Load()
        {


            Bind<IPostService>().To<PostService>();
            Bind<ICategoryService>().To<CategoryService>();
            Bind<ITagService>().To<TagService>();

            //Todo:Using Ninject Extensions
            //Bind(a=>a.)

        }

      
    }
}