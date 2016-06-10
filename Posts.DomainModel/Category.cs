using FrameWork.Domain.Model;

namespace Articles.DomainModel
{
    public class Category:EntityBase<int>,IAggregateRoot
    {
        public string Name { get; set; }

        public string Slug { get; set; }
        public string LineAge { get; set; }


    }
}