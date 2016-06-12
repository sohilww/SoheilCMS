using System;
using System.Collections.Generic;
using FrameWork.Application;
using FrameWork.Domain.Model;

namespace Articles.DomainModel
{
    public class Post:EntityBase<int>,IAggregateRoot
    {
        protected Post()
        {
            
        }
        public Post(string title,
            DateTime sendDate, DateTime? publishedDate, int visitCount,
            string content, string description, string postImage, string slug,
            int authorId, int tagId, int categoryId, AuthorRefrence author, Category category)
        {
            SetProperty(title,
                sendDate, publishedDate, visitCount,
                content, description, postImage, slug,
                authorId, tagId, categoryId, author, category);
        }

        public string Title { get; private set; }

        public DateTime SendDate { get; private set; }

        public DateTime? PublishedDate { get; private set; }

        public int VisitCount { get; private set; }

        public string Content { get; private set; }

        public string Description { get; private set; }

        public string PostImage { get; private set; }

        public string Slug { get; private set; }
        
        public int AuthorId { get; private set; }

        public int TagId { get; private set; }

        public int CategoryId { get; private set; }

        public AuthorRefrence Author { get; private set; }

        public Category Category { get; private set; }


        


        public virtual ICollection<PostTag> PostTag { get; set; }


        public void Update(string title,
            DateTime sendDate, DateTime? publishedDate, int visitCount,
            string content, string description, string postImage, string slug,
            int authorId, int tagId, int categoryId, AuthorRefrence author, Category category)
        {
            SetProperty(title,
                sendDate, publishedDate, visitCount,
                content, description, postImage, slug,
                authorId, tagId, categoryId, author, category);
        }

        private void SetProperty(string title,
            DateTime sendDate, DateTime? publishedDate, int visitCount,
            string content, string description, string postImage, string slug,
            int authorId, int tagId, int categoryId, AuthorRefrence author, Category category)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new NullReferenceException("TitleCannot Be null");

            if(sendDate == null)
            throw new NullReferenceException("Send Date Cannot Be Null");


            if (string.IsNullOrWhiteSpace(content))
                throw new NullReferenceException("Content Be null");


            if (string.IsNullOrWhiteSpace(description))
                throw new NullReferenceException("Description Be null");

            if (string.IsNullOrWhiteSpace(slug))
                throw new NullReferenceException("slug Be null");

            

            Title = title;
            SendDate = sendDate;
            PublishedDate = publishedDate;
            VisitCount = visitCount;
            Content = content;
            Description = description;
            PostImage = postImage;

            //Todo:Is That Correct
            Slug = slug.CreateFreandlySlug();
            AuthorId = authorId;
            TagId = tagId;
            CategoryId = categoryId;
            Author = author;
            Category = category;
        }
    }
}