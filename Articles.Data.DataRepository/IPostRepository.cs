using Articles.DomainModel;
using System.Collections.Generic;
using Articles.Contracts;
using FrameWork.Domain.Model;

namespace Articles.Data.DataRepository
{
    public interface IPostRepository:IRepository<int,Post>
    {
        bool SlugExsist(string slug);
        List<PostShowHomePage> HomePagePost(int count);
    }
}