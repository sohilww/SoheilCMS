using System.Data.Entity.ModelConfiguration;

namespace Articles.DomainModel.Mapping
{
    public class TagMap:EntityTypeConfiguration<Tag>
    {
        public TagMap()
        {
            ToTable("Tags");


            HasKey(a => a.Id);

            Property(a => a.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);


            Property(a => a.Name).HasColumnName("Name")
                .IsUnicode().IsRequired()
                .HasMaxLength(70);


            
        }
    }
}