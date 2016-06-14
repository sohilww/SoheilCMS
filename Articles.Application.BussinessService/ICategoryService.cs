using System;
using System.Collections.Generic;
using Articles.Contracts;
using Articles.DomainModel;
using FrameWork.Application;
using FrameWork.Core;

namespace Articles.Application.BussinessService
{
    public interface ICategoryService:IService
    {
        Category Get(int id);
        EntityAction Create(Category entity);

        EntityAction Update(Category entity);

        EntityAction Delete(int id);

        IEnumerable<Category> Where(System.Linq.Expressions.Expression<Func<Category,bool>> perdicate);

        List<CategoryModel> Select();
    }
}