using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UsingDbContext.Models;

namespace UsingDbContext.Models
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ApplicationContext(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("test"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
