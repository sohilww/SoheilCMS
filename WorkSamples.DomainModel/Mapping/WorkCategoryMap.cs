using System.Data.Entity.ModelConfiguration;

namespace WorkSamples.DomainModel.Mapping
{
    public class WorkCategoryMap : EntityTypeConfiguration<WorkCategory>
    {
        public WorkCategoryMap()
        {
            ToTable("WorkCategories");


            HasKey(a => a.Id);


            Property(a => a.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel
                .DataAnnotations.Schema.DatabaseGeneratedOption.None);

            Property(a => a.CategoryImage).IsUnicode()
                .IsOptional()
                .HasMaxLength(400);


            Property(a => a.Description).IsUnicode()
                .IsOptional()
                .HasMaxLength(300);

            Property(a => a.KeyWord).IsUnicode()
                .IsOptional()
                .HasMaxLength(400);


            Property(a => a.Slug).IsRequired()
                .IsUnicode()
                .HasMaxLength(150);

            Property(a => a.Title).IsRequired()
                .IsUnicode()
                .HasMaxLength(150);


            

            HasOptional(a => a.Parent)
                .WithMany(a => a.Children)
                .HasForeignKey(a => a.ParentId);
        }
    }
}