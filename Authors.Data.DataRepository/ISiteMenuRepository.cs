using System.Collections.Generic;
using Authors.DomainModel;
using FrameWork.Application;
using FrameWork.Domain.Model;

namespace Authors.Data.DataRepository
{
    public interface IAuthorRepository:IRepository
    {
        Author Get(int id);
        int GetNextId();

        EntityAction Create(Author entity);

        EntityAction Update(Author entity);

        EntityAction Delete(int id);

        int Count();
        List<Author> Select();
    }
}