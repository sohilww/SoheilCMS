using System.Collections.Generic;
using FrameWork.Application;
using FrameWork.Core;
using WorkSamples.DomainModel;

namespace WorkSample.Application.BussinessService
{
    public interface IWorkSampleService:IService
    {
        SampleWork Get(int id);
        EntityAction Create(SampleWork entity);

        EntityAction Update(SampleWork entity);

        EntityAction Delete(int id);

        

        int Count();

        List<SampleWork> Select();
    }
}