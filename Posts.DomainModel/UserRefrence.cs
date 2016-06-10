using FrameWork.Domain.Model;

namespace Articles.DomainModel
{
    public class UserRefrence:EntityBase<int>
    {
        public string Name { get; set; }
    }
}