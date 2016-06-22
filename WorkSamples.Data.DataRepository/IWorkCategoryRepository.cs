using System.Collections.Generic;
using FrameWork.Application;
using FrameWork.Domain.Model;
using WorkSamples.DomainModel;

namespace WorkSamples.Data.DataRepository
{
    public interface IWorkCategoryRepository:IRepository
    {
        WorkCategory Get(int id);
        int GetNextId();

        EntityAction Create(WorkCategory entity);

        EntityAction Update(WorkCategory entity);

        EntityAction Delete(int id);

        int Count();

        List<WorkCategory> SelectAllParentWorkCategory();
        List<WorkCategory> SelectAllChildOfParentWorkCategory(int parentId);
        List<WorkCategory> Select();
    }
}