using System.Data.Entity.ModelConfiguration;

namespace Authors.DomainModel.Mapping
{
    public class PostRefrenceMap:EntityTypeConfiguration<PostRefrence>
    {
        public PostRefrenceMap()
        {
            ToTable("Posts");
            HasKey(a => a.Id);

            Property(a => a.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            Property(a => a.Title)
                .HasMaxLength(256)
                .HasColumnName("Title")
                .IsUnicode()
                .IsRequired();


            HasRequired(a => a.Author)
                .WithMany(a => a.Posts)
                .HasForeignKey(a => a.AuthorId);
        }
    }
}