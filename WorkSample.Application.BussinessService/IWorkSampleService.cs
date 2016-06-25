using System.Collections.Generic;
using FrameWork.Application;
using FrameWork.Core;
using WorkSample.Contracts;
using WorkSamples.DomainModel;

namespace WorkSample.Application.BussinessService
{
    public interface IWorkSampleService:IService
    {
        SampleWorkModel Get(int id);
        EntityAction Create(SampleWorkModel entity);

        EntityAction Update(SampleWorkModel entity);

        EntityAction Delete(int id);

        

        int Count();

        List<SampleWork> Select();
    }
}