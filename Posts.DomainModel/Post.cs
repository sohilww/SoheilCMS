using System;
using FrameWork.Domain.Model;

namespace Articles.DomainModel
{
    public class Post:EntityBase<int>,IAggregateRoot
    {
        public string Title { get; set; }

        public DateTime SendDate { get; set; }

        public DateTime? PublishedDate { get; set; }

        public int VisitCount { get; set; }

        public string Content { get; set; }

        public string Description { get; set; }

        public string PostImage { get; set; }

        public string Slug { get; set; }
        
        public int AuthorId { get; set; }

        public int TagId { get; set; }

        public int CategoryId { get; set; }

        public AuthorRefrence Author { get; set; }

        public Category Category { get; set; }
    }
}