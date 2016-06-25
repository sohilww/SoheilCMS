using System;
using System.Collections.Generic;
using FrameWork.Application;
using Menu.DomainModel;
using WorkSample.Application.BussinessService;
using WorkSample.Contracts;
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

        public SampleWorkModel Get(int id)
        {
            var model = rep.Get(id);

            SampleWorkModel result = new SampleWorkModel(model);
            return result;
        }

        public EntityAction Create(SampleWorkModel entity)
        {

            var model = entity.ToSampleWork();
            model.Id = rep.GetNextId();

            EntityAction result = rep.Create(model);
            return result;
        }

        public EntityAction Update(SampleWorkModel entity)
        {
            var model = rep.Get(entity.Id);
            model=entity.ToSampleWork(model);
            model.Id = entity.Id;
            EntityAction result = rep.Update(model);
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

        public List<WorkSampleListDTO> SelectPaging(int skip, int take)
        {
            var model = rep.SelectPaging(skip, take);
            return model;
        }
    }
}