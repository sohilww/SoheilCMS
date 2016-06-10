using FrameWork.Domain.Model;

namespace Articles.DomainModel
{
    public class Post:EntityBase<int>,IAggregateRoot
    {
        public string Title { get; set; }

        public string SendDate { get; set; }

        public int VisitCount { get; set; }

        public string Content { get; set; }

        public string Description { get; set; }

        public string PostImage { get; set; }



        public int UserId { get; set; }

        public int TagId { get; set; }

        public int CategoryId { get; set; }


        public UserRefrence User { get; set; }

        public Category Category { get; set; }
    }
}