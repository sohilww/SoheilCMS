using System.Collections.Generic;
using FrameWork.Domain.Model;

namespace Menu.DomainModel
{
    public class SiteMenu:EntityBase<int>,IAggregateRoot
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        public int OrderShow { get; set; }

        public int? ParentId { get; set; }

        public SiteMenu ParentMenu { get; set; }

        public ICollection<SiteMenu> Children { get; set; }
    }
}