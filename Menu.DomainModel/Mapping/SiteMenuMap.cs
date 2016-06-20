using System.Data.Entity.ModelConfiguration;

namespace Menu.DomainModel
{
    public class SiteMenuMap : EntityTypeConfiguration<SiteMenu>
    {
        public SiteMenuMap()
        {
            ToTable("SiteMenus");


            HasKey(a => a.Id);


            Property(a => a.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel
                .DataAnnotations.Schema.DatabaseGeneratedOption.None);

            Property(a => a.Slug).IsRequired()
                .IsUnicode().HasMaxLength(100);


            Property(a => a.Title).IsRequired()
                .IsUnicode().HasMaxLength(50);


            HasOptional(a => a.ParentMenu)
                .WithMany(a => a.Children)
                .HasForeignKey(a => a.ParentId);
        }
    }
}