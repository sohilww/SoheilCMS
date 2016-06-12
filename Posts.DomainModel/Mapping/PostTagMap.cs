using System.Data.Entity.ModelConfiguration;

namespace Articles.DomainModel.Mapping
{
    public class PostTagMap:EntityTypeConfiguration<PostTag>
    {
        public PostTagMap()
        {
            ToTable("PostTags");


            HasKey(a => a.Id);


            Property(a => a.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations
                .Schema.DatabaseGeneratedOption.None);






            HasRequired(a => a.Post)
                .WithMany(a => a.PostTag)
                .HasForeignKey(a => a.PostId).WillCascadeOnDelete(false);



            HasRequired(a => a.Tag)
                .WithMany(a => a.PostTag)
                .HasForeignKey(a => a.TagId).WillCascadeOnDelete(false);





        }
    }
}