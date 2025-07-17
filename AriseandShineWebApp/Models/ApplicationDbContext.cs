using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AriseandShineWebApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add your DbSet (tables) here
        public DbSet<Sermon> Sermons { get; set; }
    }
}
