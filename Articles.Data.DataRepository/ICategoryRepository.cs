using Articles.DomainModel;
using FrameWork.Domain.Model;

namespace Articles.Data.DataRepository
{
    public interface ICategoryRepository:IRepository<int,Category>
    {
         
    }
}