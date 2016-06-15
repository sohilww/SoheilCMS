using System;
using System.Collections.Generic;
using System.Linq;
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

        public EntityAction Create(CategoryModel entity)
        {
            //  var model = entity.ToCategory();
            entity.Id = rep.GetNextId();
            if (!entity.IsParent)
            {
                var parent = rep.Get(entity.ParentId);
                entity.LineAge = parent.LineAge + "," + entity.Id.ToString();
            }
            else
            {
                entity.LineAge = entity.Id.ToString();
            }
            var model = entity.ToCategory();
            model.Id = entity.Id;
            EntityAction result = rep.Create(model);
            return result;
        }

        

        public EntityAction Delete(int id)
        {
            //Chheck Is Parent 
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
            var model = rep.Select(a => new CategoryModel()
            {
                Id = a.Id,
                IsParent = a.IsParent,
                LineAge = a.LineAge,
                Name = a.Name,
                Slug = a.Slug,
                PostCount = a.Posts.Count
            }).ToList();

            return model;
        }

        public List<SelectList> SelectList()
        {
            var model = rep.Select(a => new SelectList()
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();
            return model;
        }

        public EntityAction Update(CategoryModel model)
        {
            //Todo:Check IS Parent And Is Not Has Child
            var current = rep.Get(model.Id);
            if (current == null)
                throw new NullReferenceException("Model Cannot Be Null");
            current = model.ToCategory(current);
            EntityAction result = rep.Update(current);


            return result;


        }
    }
}