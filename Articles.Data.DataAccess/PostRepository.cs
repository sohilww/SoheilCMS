using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Articles.Data.DataRepository;
using Articles.DomainModel;
using FrameWork.Application;
using System.Linq;

namespace Articles.Data.DataAccess
{
    public class PostRepository:IPostRepository
    {
        private readonly IPostRepository rep;
        private readonly IArticlesUnitofWork unit;
        
        public PostRepository(IArticlesUnitofWork _unit)
        {
            
            this.unit = _unit;
        }

        public Post Get(int id)
        {
            var model = unit.Context.Posts.FirstOrDefault(a => a.Id == id);

            return model;

        }

        public int GetNextId()
        {
            var query = "dbo." + "PostSEQUENCE";
            int result = unit.Context
                .Database.SqlQuery<int>("SELECT NEXT VALUE FOR  " + query + ";").SingleOrDefault();
            return result;
        }

        public EntityAction Create(Post entity)
        {
            unit.Context.Posts.Add(entity);

            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Added;
            return EntityAction.Exception;
        }

        public EntityAction Update(Post entity)
        {
            unit.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Updated;
            return EntityAction.Exception;

        }

        public EntityAction Delete(int id)
        {
            unit.Context.Posts.Remove(Get(id));
            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Deleted;
            return EntityAction.Exception;


        }

        public IEnumerable<Post> Where(Expression<Func<Post, bool>> predicate)
        {
            var model = unit.Context.Posts.Where(predicate).AsQueryable();
            return model;
        }

        public void Dispose()
        {
            if (rep != null)
                rep.Dispose();
            if (unit != null)
                unit.Dispose();
        }
    }
}