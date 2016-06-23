using System.Collections.Generic;
using FrameWork.Application;
using WorkSample.Application.BussinessService;
using WorkSamples.Data.DataRepository;
using WorkSamples.DomainModel;

namespace WorkSample.Application.Bussiness
{
    public class WorkCategoryService: IWorkCategoryService
    {
        IWorkCategoryRepository rep;



        public WorkCategoryService(IWorkCategoryRepository _rep)
        {
            rep = _rep;
        }
        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        public WorkCategory Get(int id)
        {
            var result = rep.Get(id);
            return result;
        }

        public EntityAction Create(WorkCategory entity)
        {
            entity.Id = rep.GetNextId();
            EntityAction result = rep.Create(entity);
            return result;
        }

        public EntityAction Update(WorkCategory entity)
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

        public List<WorkCategory> Select()
        {
            var model = rep.Select();
            return model;
        }

    }
}