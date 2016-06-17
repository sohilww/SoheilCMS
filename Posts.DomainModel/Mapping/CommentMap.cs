using System.Data.Entity.ModelConfiguration;

namespace Articles.DomainModel.Mapping
{
    public class CommentMap:EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            ToTable("Comments");



            HasKey(a => a.Id);

            Property(a => a.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema
                .DatabaseGeneratedOption.None);

            Property(a => a.Title).IsUnicode()
                .IsRequired()
                .HasMaxLength(50);


            Property(a => a.AuthorName).IsUnicode()
                .IsRequired()
                .HasMaxLength(50);


            Property(a => a.Content).IsUnicode()
                .IsRequired()
                .HasMaxLength(300);


            Property(a => a.RegisterDate)
                .IsRequired()
                .HasColumnType("datetime2");


            HasRequired(a => a.Post)
                .WithMany(a => a.Comments)
                .HasForeignKey(a => a.PostId);


            HasOptional(a => a.ParentComment)
                .WithMany()
                .HasForeignKey(a => a.ParentCommentId);
        }
    }
}