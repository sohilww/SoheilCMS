using System.Data.Entity;
using FrameWork.Domain.Model;

namespace Articles.DomainModel
{
    public class ArticlesDbContext:BaseDbContext<ArticlesDbContext>
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }
    }

    public class Category
    {
    }

    public class Post
    {
    }
}
