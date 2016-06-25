using System;
using FrameWork.Domain.Model;

namespace WorkSamples.DomainModel
{
    public class SampleWork : EntityBase<int>, IAggregateRoot
    {
        public SampleWork(DateTime? doTime, string image, string content, string description, string slug, int workCategoryId)
        {
            SetProperty(doTime, image, content, description, slug, workCategoryId);
        }

        private void SetProperty(DateTime? doTime, string image, string content, string description, string slug, int workCategoryId)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new NullReferenceException("Content Cannot Be Null");
            if (string.IsNullOrWhiteSpace(description))
                throw new NullReferenceException("description Cannot Be Null");

            if (string.IsNullOrWhiteSpace(slug))
                throw new NullReferenceException("slug Cannot Be Null");
            DoTime = doTime;
            Image = image;
            Content = content;
            Description = description;
            Slug = slug;
            WorkCategoryId = workCategoryId;
        }

        public void Update(DateTime? doTime, string image, string content, string description, string slug, int workCategoryId)
        {
            SetProperty(doTime, image, content, description, slug, workCategoryId);
        }
        public DateTime? DoTime { get; private set; }

        public string Image { get; private set; }

        public string Content { get; private set; }

        public string Description { get; private set; }

        public string Slug { get; private set; }

        public int WorkCategoryId { get; private set; }
        public WorkCategory WorkCategory { get; set; }
    }
}