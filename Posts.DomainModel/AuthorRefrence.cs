using System.Collections.Generic;
using FrameWork.Domain.Model;

namespace Articles.DomainModel
{
    public class AuthorRefrence:EntityBase<int>
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }

        public string UserName { get; private set; }

        public ICollection<Post> Posts{ get; private set; }
    }
}