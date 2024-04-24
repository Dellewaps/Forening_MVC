using ForeningGodtfolk.Models;
using Microsoft.EntityFrameworkCore;

namespace ForeningGodtfolk.DataAcess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Event", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Klubdag", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Kursus", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Nørkledag", DisplayOrder = 4 }
                );
        }
    }
}
