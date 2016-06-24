using System.Collections.Generic;
using FrameWork.Domain.Model;

namespace WorkSamples.DomainModel
{
    public class WorkCategory:EntityBase<int>,IAggregateRoot
    {
        public WorkCategory(string title, string slug, string description, string keyWord, string categoryImage, int? parentId)
        {
            SetProperty(title, slug,
                description, keyWord, categoryImage, parentId);
        }

        protected WorkCategory()
        {
            
        }

        private void SetProperty(string title, string slug,
            string description, string keyWord, string categoryImage, int? parentId)
        {

            Title = title;
            Slug = slug;
            Description = description;
            KeyWord = keyWord;
            CategoryImage = categoryImage;
            ParentId = parentId;
        }

        public void Update(string title, string slug,
            string description, string keyWord, string categoryImage, int? parentId)
        {
            SetProperty(title, slug,
               description, keyWord, categoryImage, parentId);
        }
        public string Title { get;private set; }

        public string Slug { get;private set; }

        public string Description { get;private set; }

        public string KeyWord { get;private set; }

        public string CategoryImage { get;private set; }

        public int? ParentId { get;private set; }


        public ICollection<WorkCategory> Children { get; set; }

        public WorkCategory Parent { get; set; }


        public ICollection<SampleWork> WorkSamples { get; set; }
    }
}