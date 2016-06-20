using System.Data.Entity.ModelConfiguration;

namespace WorkSamples.DomainModel.Mapping
{
    public class WorkSampleMap:EntityTypeConfiguration<SampleWork>
    {
        public WorkSampleMap()
        {
            ToTable("WorkSamples");

            HasKey(a => a.Id);


            Property(a => a.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel
                .DataAnnotations.Schema.DatabaseGeneratedOption.None);


            Property(a => a.Content).IsUnicode()
                .IsRequired()
                .HasMaxLength(5000);


            Property(a => a.Description).IsUnicode()
                .IsRequired()
                .HasMaxLength(300);


            Property(a => a.DoTime).HasColumnType("DateTime2")
                .IsOptional();


            Property(a => a.Image).IsUnicode()
                .IsOptional()
                .HasMaxLength(400);


            Property(a => a.Slug).IsUnicode()
                .IsOptional()
                .HasMaxLength(150);


            HasRequired(a => a.WorkCategory)
                .WithMany(a => a.WorkSamples)
                .HasForeignKey(a => a.WorkCategoryId);

        }
    }
}