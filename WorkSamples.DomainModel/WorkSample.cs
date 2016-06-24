using System;
using FrameWork.Domain.Model;

namespace WorkSamples.DomainModel
{
    public class SampleWork:EntityBase<int>,IAggregateRoot
    {
        public DateTime? DoTime { get; set; }

        public string Image { get; set; }

        public string Content { get; set; }

        public string Description { get; set; }

        public string Slug { get; set; }

        public int WorkCategoryId { get; set; }
        public WorkCategory WorkCategory { get; set; }
    }
}