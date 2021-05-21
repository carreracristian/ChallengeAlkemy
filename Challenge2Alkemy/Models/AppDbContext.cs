using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Challenge2Alkemy.Models
{
    public class AppDbContext:DbContext
    {
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog:PostsAlkemy;Integrated Security=True")
            .EnableSensitiveDataLogging(true);
                //.UseLoggerFactory(new LoggerFactory().add)
        }*/
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<PostViewModel> Post { get; set; }
    }
}
