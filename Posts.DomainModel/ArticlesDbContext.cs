using System.Data.Entity;
using Articles.DomainModel.Mapping;
using FrameWork.Domain.Model;

namespace Articles.DomainModel
{
    public class ArticlesDbContext:BaseDbContext<ArticlesDbContext>
    {
        public ArticlesDbContext()
        {
            
        }


        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<AuthorRefrence> UserRefrences { get; set; }

        public DbSet<PostTag> PostTags { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PostMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new UserRefrenceMap());

            modelBuilder.Configurations.Add(new TagMap());
            modelBuilder.Configurations.Add(new PostTagMap());

            modelBuilder.Configurations.Add(new CommentMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
