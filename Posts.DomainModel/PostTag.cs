using System.Collections;
using System.Collections.Generic;
using FrameWork.Domain.Model;

namespace Articles.DomainModel
{
    public class PostTag:EntityBase<int>,IAggregateRoot
    {
        public int PostId { get; set; }


        public int TagId { get; set; }

        public virtual Post Post { get; set; }

        public virtual Tag Tag { get; set; }
    }
}