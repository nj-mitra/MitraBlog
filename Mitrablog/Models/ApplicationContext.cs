using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mitrablog.Models.Account;
using Mitrablog.Models.Emails;
using Mitrablog.Models.Posts;

namespace Mitrablog.Models
{
    public class ApplicationContext : IdentityDbContext<AppUser>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Comment> Comments { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;Database=MitraBlog;integrated security =True;");
        }
    }

}

