using Articles.DomainModel;
using FrameWork.Domain.Model;

namespace Articles.Data.DataRepository
{
    public interface IArticlesUnitofWork:IUnitOfWork<ArticlesDbContext>
    {
         
    }
}