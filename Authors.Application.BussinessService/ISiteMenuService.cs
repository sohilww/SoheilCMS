using System.Collections.Generic;
using Authors.DomainModel;
using FrameWork.Application;
using FrameWork.Core;

namespace Authors.Application.BussinessService
{
    public interface IAuthorService:IService
    {
        Author Get(int id);
        EntityAction Create(Author entity);

        EntityAction Update(Author entity);

        EntityAction Delete(int id);

        

        int Count();

        List<Author> Select();
    }
}