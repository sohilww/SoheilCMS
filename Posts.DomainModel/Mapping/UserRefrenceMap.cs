using System.Data.Entity.ModelConfiguration;

namespace Articles.DomainModel.Mapping
{
    public class UserRefrenceMap:EntityTypeConfiguration<AuthorRefrence>
    {
        public UserRefrenceMap()
        {
            ToTable("Authors");

            HasKey(a => a.Id);


            Property(a => a.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.
                DataAnnotations.Schema.DatabaseGeneratedOption.None);


            Property(a => a.Name).HasColumnName("Name")
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(90);

            Property(a => a.LastName).HasColumnName("LastName")
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(150);


            Property(a => a.UserName).HasColumnName("UserName")
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(150);


        }
    }
}