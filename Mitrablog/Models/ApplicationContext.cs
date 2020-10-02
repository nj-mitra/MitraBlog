using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mitrablog.Models
{
    public class ApplicationContext:DbContext

    {
        public DbSet<Post> Posts { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;Database=MitraBlog;integrated security =True;");
        }
    }
   
}

