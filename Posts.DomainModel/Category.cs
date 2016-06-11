using System.Collections.Generic;
using FrameWork.Domain.Model;

namespace Articles.DomainModel
{
    public class Category:EntityBase<int>,IAggregateRoot
    {
        public string Name { get; set; }

        public string Slug { get; set; }


        public bool IsParent { get; set; }


        public string LineAge { get; set; }


        public ICollection<Post> Posts { get; set; }


    }
}