using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Articles.Data.DataRepository;
using Articles.DomainModel;
using FrameWork.Application;
using System.Linq;

namespace Articles.Data.DataAccess
{
    public class CategoryRepository:ICategoryRepository
    {
        
        private readonly IArticlesUnitofWork unit;
        
        public CategoryRepository(IArticlesUnitofWork _unit)
        {
            
            this.unit = _unit;
        }

        public Category Get(int id)
        {
            var model = unit.Context.Categories.FirstOrDefault(a => a.Id == id);

            return model;

        }

        public int GetNextId()
        {
            var query = "dbo." + "CategorySEQUENCE";
            int result = unit.Context
                .Database.SqlQuery<int>("SELECT NEXT VALUE FOR  " + query + ";").SingleOrDefault();
            return result;
        }

        public EntityAction Create(Category entity)
        {
            unit.Context.Categories.Add(entity);

            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Added;
            return EntityAction.Exception;
        }

        public EntityAction Update(Category entity)
        {
            unit.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Updated;
            return EntityAction.Exception;

        }

        public EntityAction Delete(int id)
        {
            unit.Context.Categories.Remove(Get(id));
            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Deleted;
            return EntityAction.Exception;


        }

        public IQueryable<Category> Where(Expression<Func<Category, bool>> predicate)
        {
            var model = unit.Context.Categories.Where(predicate).AsQueryable();
            return model;
        }

        public IQueryable<Category> SelectAll()
        {
            var model = unit.Context.Categories.AsQueryable();
            return model;
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<Category, TResult>> predicate)
        {
            var model = unit.Context.Categories.Select(predicate);
            return model;
        }

        public void Dispose()
        {
           
            if (unit != null)
                unit.Dispose();
        }
    }
}