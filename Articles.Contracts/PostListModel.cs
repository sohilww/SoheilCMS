using System;
using System.Collections.Generic;
using Articles.DomainModel;

namespace Articles.Contracts
{
    public class PostListModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }

        public DateTime SendDate { get; set; }

        public DateTime? PublishedDate { get; set; }

        public int VisitCount { get; set; }

        
        public string PostImage { get; set; }

        
        public int AuthorId { get; set; }

        public int TagId { get; set; }

        public int CategoryId { get; set; }

        public AuthorRefrence Author { get; set; }

        public Category Category { get; set; }

        public  ICollection<PostTag> PostTag { get; set; }

        public  ICollection<Comment> Comments { get; set; }
    }
}