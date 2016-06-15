using System;
using System.Collections.Generic;
using Articles.Contracts;
using Articles.DomainModel;
using FrameWork.Application;
using FrameWork.Core;

namespace Articles.Application.BussinessService
{
    public interface ITagService:IService
    {
        Tag Get(int id);
        EntityAction Create(Tag entity);

        EntityAction Update(Tag entity);

        EntityAction Delete(int id);

        List<Tag> Where(System.Linq.Expressions.Expression<Func<Tag,bool>> perdicate);

        List<TagModel> Select();
    }
}