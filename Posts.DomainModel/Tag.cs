using System.Collections.Generic;
using FrameWork.Domain.Model;

namespace Articles.DomainModel
{
    public class Tag:EntityBase<int>,IAggregateRoot
    {

        public string Name { get; set; }

        

        

        public virtual ICollection<PostTag> PostTag { get; set; }
    }
}