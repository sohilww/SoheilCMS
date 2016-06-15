using Articles.DomainModel;

namespace Articles.Contracts
{
    public class TagModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PostCount { get; set; }


        public Tag ToCategory(Tag tag=null)
        {
            if (tag == null)
                return new Tag(this.Name);
            else
            {
                tag.Update(Name);
                return tag;
            }
        }
    }
}
