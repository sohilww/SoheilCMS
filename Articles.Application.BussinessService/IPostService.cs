using System;
using System.Collections.Generic;
using Articles.DomainModel;
using FrameWork.Application;
using FrameWork.Core;

namespace Articles.Application.BussinessService
{
    public interface IPostService:IService
    {
        Post Get(int id);
        EntityAction Create(Post entity);

        EntityAction Update(Post entity);

        EntityAction Delete(int id);

        IEnumerable<Post> Where(System.Linq.Expressions.Expression<Func<Post,bool>> perdicate);

    }
}