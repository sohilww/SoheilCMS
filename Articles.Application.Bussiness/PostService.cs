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

        public PostCreateModel Get(int id)
        {
            var tmp = rep.Get(id);
            PostCreateModel result = new PostCreateModel()
            {
                Author = tmp.Author,
                AuthorId = tmp.AuthorId,
                Category = tmp.Category,
                CategoryId = tmp.CategoryId,
                Comments = tmp.Comments,
                Content = tmp.Content,
                Description = tmp.Description,
                PostId = tmp.Id,
                PostImage = tmp.PostImage,
                PostTag = tmp.PostTag,
                PublishedDate = tmp.PublishedDate,
                SendDate = tmp.SendDate,
                Slug = tmp.Slug,
                TagId = tmp.TagId,
                Title = tmp.Title,
                VisitCount = tmp.VisitCount
            };
            return result;
        }

        public EntityAction Create(PostCreateModel entity)
        {
            if (SlugExsits(entity.Slug))
                return EntityAction.Exception;
            entity.PostId = rep.GetNextId();
            var post = entity.ToPost();
            EntityAction result = rep.Create(post);
            return result;
        }

        public EntityAction Update(PostCreateModel entity)
        {

            //Todo: The Slug Has Not Exsits 
            var post = rep.Get(entity.PostId);
            //post.CategoryId;
            post.Category = null;
            entity.ToPost(post);
            EntityAction result = rep.Update(post);
            return result;
        }

        private bool SlugExsits(string slug)
        {
            slug = slug.ToLower().CreateFreandlySlug();
            return rep.SlugExsist(slug);

        }
        public EntityAction Delete(int id)
        {
            EntityAction result = rep.Delete(id);
            return result;
        }



        public List<PostListModel> Select(int skip, int take)
        {
            var result = rep.SelectAll().OrderBy(a => a.Id).Skip(skip).Take(take)
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
            var result = rep.SelectAll()
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

        public List<PostShowHomePage> HomePagePost(int count)
        {
            var model = rep.HomePagePost(count);
            return model;
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