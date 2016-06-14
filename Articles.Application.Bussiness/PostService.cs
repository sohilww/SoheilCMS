using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Articles.Application.BussinessService;
using Articles.Data.DataRepository;
using Articles.DomainModel;
using FrameWork.Application;

namespace Articles.Application.Bussiness
{
    public class PostService:IPostService
    {
        IPostRepository rep;

        public PostService(IPostRepository _rep)
        {
            rep = _rep;
        }
        public void Dispose()
        {
           // throw new NotImplementedException();
        }

        public Post Get(int id)
        {
            var result = rep.Get(id);
            return result;
        }

        public EntityAction Create(Post entity)
        {
            entity.Id = rep.GetNextId();
            EntityAction result = rep.Create(entity);
            return result;
        }

        public EntityAction Update(Post entity)
        {
            EntityAction result = rep.Update(entity);
            return result;
        }

        public EntityAction Delete(int id)
        {
            EntityAction result = rep.Delete(id);
            return result;
        }

        public List<Post> Where(Expression<Func<Post, bool>> perdicate)
        {
            var result = rep.Where(perdicate).ToList();
            return result;
        }
    }
}