using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Articles.Data.DataRepository;
using Articles.DomainModel;
using FrameWork.Application;
using System.Linq;

namespace Articles.Data.DataAccess
{
    public class TagRepository:ITagRepository
    {
        private readonly ITagRepository rep;
        private readonly IArticlesUnitofWork unit;
        
        public TagRepository(IArticlesUnitofWork _unit)
        {
            
            this.unit = _unit;
        }

        public Tag Get(int id)
        {
            var model = unit.Context.Tags.FirstOrDefault(a => a.Id == id);

            return model;

        }

        public int GetNextId()
        {
            var query = "dbo." + "TagSEQUENCE";
            int result = unit.Context
                .Database.SqlQuery<int>("SELECT NEXT VALUE FOR  " + query + ";").SingleOrDefault();
            return result;
        }

        public EntityAction Create(Tag entity)
        {
            unit.Context.Tags.Add(entity);

            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Added;
            return EntityAction.Exception;
        }

        public EntityAction Update(Tag entity)
        {
            unit.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Updated;
            return EntityAction.Exception;

        }

        public EntityAction Delete(int id)
        {
            unit.Context.Tags.Remove(Get(id));
            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Deleted;
            return EntityAction.Exception;


        }

        public IEnumerable<Tag> Where(Expression<Func<Tag, bool>> predicate)
        {
            var model = unit.Context.Tags.Where(predicate).AsQueryable();
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