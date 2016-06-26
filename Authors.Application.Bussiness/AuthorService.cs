using System.Collections.Generic;
using Authors.Application.BussinessService;
using Authors.Data.DataRepository;
using Authors.DomainModel;
using FrameWork.Application;

namespace Authors.Application.Bussiness
{
    public class AuthorService : IAuthorService
    {
        IAuthorRepository rep;

        public AuthorService(IAuthorRepository _rep)
        {
            rep = _rep;
        }
        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        public Author Get(int id)
        {
            var result = rep.Get(id);
            return result;
        }

        public EntityAction Create(Author entity)
        {
            entity.Id = rep.GetNextId();
            EntityAction result = rep.Create(entity);
            return result;
        }

        public EntityAction Update(Author entity)
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

        public List<Author> Select()
        {
            var model = rep.Select();
            return model;
        }
    }
}