using System.Collections.Generic;
using FrameWork.Domain.Model;
using System;

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


        public void Update(string name)
        {
            SetProperty(name);
        }

        public virtual ICollection<PostTag> PostTag { get; set; }

        private void SetProperty(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new NullReferenceException("Name Cannot Be Null");
            Name = name;
        }
    }
}