using System.Collections.Generic;
using FrameWork.Application;
using FrameWork.Core;
using WorkSample.Contracts;
using WorkSamples.DomainModel;

namespace WorkSample.Application.BussinessService
{
    public interface IWorkCategoryService : IService
    {
        WorkCategoryModel Get(int id);
        EntityAction Create(WorkCategoryModel entity);

        EntityAction Update(WorkCategoryModel entity);

        EntityAction Delete(int id);



        int Count();

        List<WorkCategoryModel> Select();
        List<SelectList> SelectIdAndName();
    }
}