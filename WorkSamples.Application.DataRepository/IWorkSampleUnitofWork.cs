using FrameWork.Domain.Model;
using WorkSamples.DomainModel;

namespace WorkSamples.Application.DataRepository
{
    public interface IWorkSampleUnitofWork:IUnitOfWork<WorkSampleDbContext>
    {
         
    }
}