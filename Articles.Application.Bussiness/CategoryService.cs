using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Articles.Application.BussinessService;
using Articles.Contracts;
using Articles.Data.DataRepository;
using Articles.DomainModel;
using FrameWork.Application;

namespace Articles.Application.Bussiness
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository rep;

        public CategoryService(ICategoryRepository _rep)
        {
            rep = _rep;
        }
        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            var result = rep.Get(id);
            return result;
        }

        public EntityAction Create(Category entity)
        {
            entity.Id = rep.GetNextId();
            EntityAction result = rep.Create(entity);
            return result;
        }

        public EntityAction Update(Category entity)
        {
            EntityAction result = rep.Update(entity);
            return result;
        }

        public EntityAction Delete(int id)
        {
            EntityAction result = rep.Delete(id);
            return result;
        }

        public IEnumerable<Category> Where(Expression<Func<Category, bool>> perdicate)
        {
            var result = rep.Where(perdicate);
            return result;
        }

        public List<CategoryModel> Select()
        {
            var model =(List<CategoryModel>)rep.Select(a => new CategoryModel()
            {
                Id = a.Id,
                IsParent = a.IsParent,
                LineAge = a.LineAge,
                Name = a.Name,
                Slug = a.Slug,
                PostCount = a.Posts.Count
            });

            return model;
        }
    }
}