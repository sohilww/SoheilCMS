using System.Collections.Generic;
using Authors.Data.DataRepository;
using System.Linq;
using Authors.DomainModel;
using FrameWork.Application;

namespace Authors.Data.DataAccess
{
    public class AuthorRepository:IAuthorRepository
    {
        
        private readonly IAuthorUnitofWork unit;
        
        public AuthorRepository(IAuthorUnitofWork _unit)
        {
            
            this.unit = _unit;
        }

        public Author Get(int id)
        {
            var model = unit.Context.Authors.FirstOrDefault(a => a.Id == id);

            return model;

        }

        public int GetNextId()
        {
            var query = "dbo." + "AuthorSEQUENCE";
            int result = unit.Context
                .Database.SqlQuery<int>("SELECT NEXT VALUE FOR  " + query + ";").SingleOrDefault();
            return result;
        }

        public EntityAction Create(Author entity)
        {
            unit.Context.Authors.Add(entity);

            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Added;
            return EntityAction.Exception;
        }

        public EntityAction Update(Author entity)
        {
            unit.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Updated;
            return EntityAction.Exception;

        }

        public EntityAction Delete(int id)
        {
            unit.Context.Authors.Remove(Get(id));
            if (unit.SaveChanges() == EntityAction.Success)
                return EntityAction.Deleted;
            return EntityAction.Exception;


        }

        

        public int Count()
        {
            return unit.Context.Authors.Count();
        }

     
        public List<Author> Select()
        {
            var model = unit.Context.Authors.ToList();
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