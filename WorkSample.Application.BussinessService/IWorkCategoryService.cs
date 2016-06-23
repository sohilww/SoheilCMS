using System.Collections.Generic;
using FrameWork.Application;
using FrameWork.Core;
using WorkSamples.DomainModel;

namespace WorkSample.Application.BussinessService
{
    public interface IWorkCategoryService:IService
    {
        WorkCategory Get(int id);
        EntityAction Create(WorkCategory entity);

        EntityAction Update(WorkCategory entity);

        EntityAction Delete(int id);



        int Count();

        List<WorkCategory> Select();
    }
}