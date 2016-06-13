using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Articles.Application.BussinessService;
using Articles.Data.DataRepository;
using Articles.DomainModel;
using FrameWork.Application;

namespace Articles.Application.Bussiness
{
    public class TagService:ITagService
    {
        ITagRepository rep;

        public TagService(ITagRepository _rep)
        {
            rep = _rep;
        }
        public void Dispose()
        {
           // throw new NotImplementedException();
        }

        public Tag Get(int id)
        {
            var result = rep.Get(id);
            return result;
        }

        public EntityAction Create(Tag entity)
        {
            entity.Id = rep.GetNextId();
            EntityAction result = rep.Create(entity);
            return result;
        }

        public EntityAction Update(Tag entity)
        {
            EntityAction result = rep.Update(entity);
            return result;
        }

        public EntityAction Delete(int id)
        {
            EntityAction result = rep.Delete(id);
            return result;
        }

        public IEnumerable<Tag> Where(Expression<Func<Tag, bool>> perdicate)
        {
            var result = rep.Where(perdicate);
            return result;
        }
    }
}