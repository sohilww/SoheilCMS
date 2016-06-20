using System;
using System.Collections.Generic;
using System.Linq;
using FrameWork.Application;
using WorkSamples.Data.DataRepository;
using WorkSamples.DomainModel;

namespace WorkSample.Data.DataAccess
{
    public class WorkSampleRepository:IWorkSampleRepository
    {
        
        private readonly IWorkSampleUnitofWork unit;
        
        public WorkSampleRepository(IWorkSampleUnitofWork _unit)
        {
            
            this.unit = _unit;
        }

        public SampleWork Get(int id)
        {
            var model = unit.Context.WorkSamples.FirstOrDefault(a => a.Id == id);

            return model;

        }

        public int GetNextId()
        {
            var query = "dbo." + "WorkSampleSEQUENCE";
            int result = unit.Context
                .Database.SqlQuery<int>("SELECT NEXT VALUE FOR  " + query + ";").SingleOrDefault();
            return result;
        }

        public EntityAction Create(SampleWork entity)
        {
            unit.Context.WorkSamples.Add(entity);

            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Added;
            return EntityAction.Exception;
        }

        public EntityAction Update(SampleWork entity)
        {
            unit.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Updated;
            return EntityAction.Exception;

        }

        public EntityAction Delete(int id)
        {
            unit.Context.WorkSamples.Remove(Get(id));
            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Deleted;
            return EntityAction.Exception;


        }

        

        public int Count()
        {
            return unit.Context.WorkSamples.Count();
        }

        
        public List<SampleWork> Select()
        {
            var model = unit.Context.WorkSamples.ToList();
            return model;
        }


        public void Dispose()
        {
            //if (rep != null)
            //    rep.Dispose();
            //if (unit != null)
            //    unit.Dispose();
        }

       
    }

}