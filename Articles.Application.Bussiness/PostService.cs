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
    public class PostService : IPostService
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



        public List<PostListModel> Select(int skip, int take)
        {
            var result=rep.SelectAll().OrderBy(a=>a.Id).Skip(skip).Take(take)
                .Select(a => new PostListModel()
                {
                    Author = a.Author,
                    AuthorId = a.AuthorId,
                    Category = a.Category,
                    CategoryId = a.CategoryId,
                    Comments = a.Comments,
                    PostId = a.Id,
                    PostTag = a.PostTag,
                    PublishedDate = a.PublishedDate,
                    SendDate = a.SendDate,
                    Title = a.Title,
                    VisitCount = a.VisitCount,
                    TagId = a.TagId,
                    PostImage = a.PostImage
                }).ToList();
            return result;
        }

        public List<PostListModel> SelectAll()
        {
            var result=rep.SelectAll()
                .Select(a => new PostListModel()
                {
                    Author = a.Author,
                    AuthorId = a.AuthorId,
                    Category = a.Category,
                    CategoryId = a.CategoryId,
                    Comments = a.Comments,
                    PostId = a.Id,
                    PostTag = a.PostTag,
                    PublishedDate = a.PublishedDate,
                    SendDate = a.SendDate,
                    Title = a.Title,
                    VisitCount = a.VisitCount,
                    TagId = a.TagId,
                    PostImage = a.PostImage
                }).ToList();
            return result;
        }

        public int Count()
        {
            return rep.Count();
        }

        public List<PostListModel> Where(Expression<Func<Post, bool>> perdicate)
        {
            var result = rep.Where(perdicate).Select(a => new PostListModel()
            {
                Author = a.Author,
                AuthorId = a.AuthorId,
                Category = a.Category,
                CategoryId = a.CategoryId,
                Comments = a.Comments,
                PostId = a.Id,
                PostTag = a.PostTag,
                PublishedDate = a.PublishedDate,
                SendDate = a.SendDate,
                Title = a.Title,
                VisitCount = a.VisitCount,
                TagId = a.TagId,
                PostImage = a.PostImage
            }).ToList();
            return result;
        }
    }
}