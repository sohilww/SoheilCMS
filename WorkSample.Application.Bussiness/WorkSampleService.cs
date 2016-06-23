using System;
using System.Collections.Generic;
using FrameWork.Application;
using Menu.DomainModel;
using WorkSample.Application.BussinessService;
using WorkSamples.Data.DataRepository;
using WorkSamples.DomainModel;

namespace WorkSample.Application.Bussiness
{
    public class WorkSampleService:IWorkSampleService
    {
        IWorkSampleRepository rep;

       

        public WorkSampleService(IWorkSampleRepository _rep)
        {
            rep = _rep;
        }
        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        public SampleWork Get(int id)
        {
            var result = rep.Get(id);
            return result;
        }

        public EntityAction Create(SampleWork entity)
        {
            entity.Id = rep.GetNextId();
            EntityAction result = rep.Create(entity);
            return result;
        }

        public EntityAction Update(SampleWork entity)
        {
            EntityAction result = rep.Update(entity);
            return result;
        }

        public EntityAction Delete(int id)
        {
            EntityAction result = rep.Delete(id);
            return result;
        }



        public int Count()
        {
            return rep.Count();
        }

        public List<SampleWork> Select()
        {
            var model = rep.Select();
            return model;
        }
        
    }
}