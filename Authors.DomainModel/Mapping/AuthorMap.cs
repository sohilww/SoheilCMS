using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Authors.DomainModel.Mapping
{
    public class AuthorMap : EntityTypeConfiguration<Author>
    {
        public AuthorMap()
        {
            ToTable("Authors");

            HasKey(a => a.Id);



            Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);


            Property(a => a.Name).HasColumnName("Name")
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(90);

            Property(a => a.Password).HasColumnName("Password")
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(480);

            Property(a => a.LastName).HasColumnName("LastName")
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(150);


            Property(a => a.UserName).HasColumnName("UserName")
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_UserName") { IsUnique=true }
                }));

            Property(a => a.Email).HasColumnName("Email")
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(150).HasColumnAnnotation("Index", new IndexAnnotation(new[]
                {
                    new IndexAttribute("IX_Email") { IsUnique=true }
                }));

        }
    }
}