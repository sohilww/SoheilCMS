using System;
using System.Collections.Generic;
using System.Linq;
using FrameWork.Application;
using WorkSample.Contracts;
using WorkSamples.Data.DataRepository;
using WorkSamples.DomainModel;

namespace WorkSample.Data.DataAccess
{
    public class WorkCategoryRepository : IWorkCategoryRepository
    {

        private readonly IWorkSampleUnitofWork unit;

        public WorkCategoryRepository(IWorkSampleUnitofWork _unit)
        {

            this.unit = _unit;
        }

        public WorkCategory Get(int id)
        {
            var model = unit.Context.WorkCategories.FirstOrDefault(a => a.Id == id);

            return model;

        }

        public int GetNextId()
        {
            var query = "dbo." + "WorkCategorySEQUENCE";
            int result = unit.Context
                .Database.SqlQuery<int>("SELECT NEXT VALUE FOR  " + query + ";").SingleOrDefault();
            return result;
        }

        public EntityAction Create(WorkCategory entity)
        {
            unit.Context.WorkCategories.Add(entity);

            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Added;
            return EntityAction.Exception;
        }

        public EntityAction Update(WorkCategory entity)
        {
            unit.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Updated;
            return EntityAction.Exception;

        }

        public EntityAction Delete(int id)
        {
            unit.Context.WorkCategories.Remove(Get(id));
            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Deleted;
            return EntityAction.Exception;


        }



        public int Count()
        {
            return unit.Context.SampleWork.Count();
        }

        public List<WorkCategory> SelectAllParentWorkCategory()
        {
            var model = unit.Context.WorkCategories.Where(a => a.ParentId == null).ToList();
            return model;
        }

        public List<WorkCategory> SelectAllChildOfParentWorkCategory(int parentId)
        {
            var model = unit.Context.WorkCategories.Where(a => a.ParentId == parentId).ToList();
            return model;
        }

        public List<WorkCategory> Select()
        {
            var model = unit.Context.WorkCategories.ToList();
            return model;
        }

        public List<SelectList> SelectIdAndName()
        {
            var model = unit.Context.WorkCategories.Select(a => new SelectList()
            {
                Id = a.Id,
                Name = a.Title
            }).ToList();
            return model;

        }

        public List<WorkCategoryBaseDTO> GetBaseCategory(int take)
        {
            var model = unit.Context.WorkCategories.Take(take)
                .Select(a => new WorkCategoryBaseDTO()
                {
                    Id = a.Id,
                    Name = a.Title,
                    Slug = a.Slug,
                    Samples = a.WorkSamples.Take(3)

                }).ToList();

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