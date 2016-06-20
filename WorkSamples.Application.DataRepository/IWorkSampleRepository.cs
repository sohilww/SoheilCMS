using System.Collections.Generic;
using FrameWork.Application;
using FrameWork.Domain.Model;
using WorkSamples.DomainModel;

namespace WorkSamples.Data.DataRepository
{
    public interface IWorkSampleRepository:IRepository
    {
        WorkSample Get(int id);
        int GetNextId();

        EntityAction Create(WorkSample entity);

        EntityAction Update(WorkSample entity);

        EntityAction Delete(int id);

        int Count();

        List<WorkSample> SelectAllParentWorkSample();
        List<WorkSample> SelectAllChildOfParentWorkSample(int parentId);
        List<WorkSample> Select();
    }
}