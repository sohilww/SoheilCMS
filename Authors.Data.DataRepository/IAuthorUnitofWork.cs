using Authors.DomainModel;
using FrameWork.Domain.Model;

namespace Authors.Data.DataRepository
{
    public interface IAuthorUnitofWork: IUnitOfWork<AuthorDbContext>
    {
        
    }
}