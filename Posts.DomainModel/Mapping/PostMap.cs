using System.Data.Entity.ModelConfiguration;

namespace Articles.DomainModel.Mapping
{
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            ToTable("Posts");


            HasKey(a => a.Id);


            Property(a => a.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            Property(a => a.Content).IsRequired()
                .IsUnicode().HasColumnName("Content");
            Property(a => a.Description).IsRequired()
                .IsUnicode().HasColumnName("Description").HasMaxLength(256);

            Property(a => a.PostImage)
                .IsUnicode()
                .HasMaxLength(256)
                .HasColumnName("PostImage");

            Property(a => a.PublishedDate).HasColumnName("PublishedDate")
                .HasColumnType("DateTime2").IsOptional();

            Property(a => a.SendDate).HasColumnName("SendDate")
                .HasColumnType("DateTime2").IsRequired();

            Property(a => a.Slug).IsUnicode().IsRequired()
                .HasColumnName("Slug")
                .HasMaxLength(256);

            Property(a => a.Title)
                .HasMaxLength(256)
                .HasColumnName("Title")
                .IsUnicode()
                .IsRequired();


            Property(a => a.VisitCount).IsRequired()
                .HasColumnName("VisitCount");





            HasRequired(a => a.Author)
                .WithMany(a => a.Posts)
                .HasForeignKey(a => a.AuthorId);





            HasRequired(a => a.Category)
                .WithMany(a => a.Posts)
                .HasForeignKey(a => a.CategoryId);



        }
    }
}