using System.Data.Entity;
using Authors.DomainModel.Mapping;
using FrameWork.Domain.Model;

namespace Authors.DomainModel
{
    public class AuthorDbContext:BaseDbContext<AuthorDbContext>
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<PostRefrence> Post { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorMap());
            modelBuilder.Configurations.Add(new PostRefrenceMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}