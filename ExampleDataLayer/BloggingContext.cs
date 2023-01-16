using ExampleDataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleDataLayer
{

    public class BloggingContext : DbContext
    {
        public DbSet<BlogEntity> Blogs { get; set; }
        public DbSet<PostEntity> Posts { get; set; }

        public BloggingContext()
        {
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql($"User ID=example_api_db_user;Password=example_api_db_password;Host=localhost;Port=5432;Database=postgresql;");
    }
}
