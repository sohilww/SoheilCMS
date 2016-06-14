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



    }
}
