using System;
using FrameWork.Domain.Model;

namespace Articles.DomainModel
{
    public class Comment:EntityBase<int>
    {
        public string Title { get; set; }

        public string AuthorName { get; set; }

        public string Content { get; set; }

        public int PostId { get; set; }

        public DateTime RegisterDate { get; set; }

        public int? ParentCommentId { get; set; }

        public Post Post { get; set; }

        public Comment ParentComment { get; set; }


    }
}