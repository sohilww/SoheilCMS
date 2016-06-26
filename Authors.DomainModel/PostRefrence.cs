using System.Collections.Generic;
using FrameWork.Domain.Model;

namespace Authors.DomainModel
{
    public class PostRefrence:EntityBase<int>
    {
        protected PostRefrence()
        {
            
        }

        public string Title { get;private set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}