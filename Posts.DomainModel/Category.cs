using System.Collections.Generic;
using FrameWork.Domain.Model;
using System;
using FrameWork.Application;

namespace Articles.DomainModel
{
    public class Category:EntityBase<int>,IAggregateRoot
    {
        protected Category()
        {
            
        }
        public Category(string name, string slug,
            bool isParent, string lineAge)
        {
            SetProperty(name, slug, isParent, lineAge);
        }

        public string Name { get; private set; }

        public string Slug { get; private set; }


        public bool IsParent { get; private set; }


        public string LineAge { get; private set; }


        public ICollection<Post> Posts { get; private set; }

        private void SetProperty(string name, string slug, bool isParent, string lineAge)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new NullReferenceException("Name Cannot Be Null");

            if (string.IsNullOrWhiteSpace(slug))
                throw new NullReferenceException("Slug Cannot Be Null");



            Name = name;
            Slug = slug.CreateFreandlySlug();
            IsParent = isParent;
            LineAge = lineAge;
        }

        public void Update(string name, string slug, bool isParent, string lineAge)
        {
            SetProperty(name, slug, isParent, lineAge);
        }

    }
}