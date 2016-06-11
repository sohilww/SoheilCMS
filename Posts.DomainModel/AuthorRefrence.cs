using System.Collections.Generic;
using FrameWork.Domain.Model;

namespace Articles.DomainModel
{
    public class AuthorRefrence:EntityBase<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }

        public ICollection<Post> Posts{ get; set; }
    }
}