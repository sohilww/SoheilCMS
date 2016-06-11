using System.Data.Entity.ModelConfiguration;

namespace Articles.DomainModel.Mapping
{
    public class CategoryMap:EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable("Categories");

            HasKey(a => a.Id);


            Property(a => a.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel
                .DataAnnotations.Schema.DatabaseGeneratedOption.None);


            Property(a => a.Name)
                .IsRequired().IsUnicode()
                .HasMaxLength(50)
                .HasColumnName("Name");

            Property(a => a.IsParent).HasColumnName("IsParent");


            Property(a => a.LineAge)
                .HasColumnName("LineAge")
                .IsOptional();

        }
    }
}