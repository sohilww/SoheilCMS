using System.Collections.Generic;
using FrameWork.Application;
using FrameWork.Domain.Model;
using WorkSamples.DomainModel;

namespace WorkSamples.Data.DataRepository
{
    public interface IWorkSampleRepository:IRepository
    {
        SampleWork Get(int id);
        int GetNextId();

        EntityAction Create(SampleWork entity);

        EntityAction Update(SampleWork entity);

        EntityAction Delete(int id);

        int Count();

        List<SampleWork> Select();
    }
}