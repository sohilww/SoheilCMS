using System.Collections.Generic;
using FrameWork.Domain.Model;

namespace WorkSamples.DomainModel
{
    public class WorkCategory:EntityBase<int>,IAggregateRoot
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public string KeyWord { get; set; }

        public string CategoryImage { get; set; }

        public int? ParentId { get; set; }


        public ICollection<WorkCategory> Children { get; set; }

        public WorkCategory Parent { get; set; }


        public ICollection<WorkSample> WorkSamples { get; set; }
    }
}