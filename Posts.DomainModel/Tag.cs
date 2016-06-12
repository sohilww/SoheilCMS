using System.Collections.Generic;
using FrameWork.Domain.Model;

namespace Articles.DomainModel
{
    public class Tag : EntityBase<int>, IAggregateRoot
    {

        protected Tag()
        {

        }
        public Tag(string name)
        {
            SetProperty(name);
        }

        public string Name { get; private set; }




        public virtual ICollection<PostTag> PostTag { get; set; }

        private void SetProperty(string name)
        {
            Name = name;
        }
    }
}