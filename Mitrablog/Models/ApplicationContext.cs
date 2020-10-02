using Microsoft.EntityFrameworkCore;
using Mitrablog.Models.Posts;

namespace Mitrablog.Models
{
    public class ApplicationContext : DbContext

    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;Database=MitraBlog;integrated security =True;");
        }
    }

}

