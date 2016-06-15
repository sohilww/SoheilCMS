using Articles.DomainModel;

namespace Articles.Contracts
{
    public class CategoryModel
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Slug { get; set; }


        public virtual bool IsParent { get; set; }


        public virtual string LineAge { get; set; }

        public virtual int PostCount { get; set; }
        public int ParentId { get; set; }


        public Category ToCategory(Category category=null)
        {
            if (category == null)
                return new Category(name: this.Name, slug: Slug, isParent: IsParent, lineAge: LineAge);
            else
            {
                category.Update(name: this.Name, slug: Slug, isParent: IsParent, lineAge: LineAge);
                return category;
            }
        }
    }
}
