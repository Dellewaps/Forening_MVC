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
        public DbSet<History> Historys { get; set; }

        public DbSet<Calender> Calender { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Event", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Klubdag", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Kursus", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Nørkledag", DisplayOrder = 4 }
                );

            modelBuilder.Entity<History>().HasData(
                new History { Id = 1,
                    Title = "Tylstrup Middelalder Marked",
                    Description = "Markedet hvor der vises håndværk fra gammle tider og sælges ting",
                    Date = new DateOnly(2024, 05, 08),
                    CategoryId = 1,
                    ImageUrl =""
                },
                new History { 
                    Id = 2, 
                    Title = "Lindholm Marked", 
                    Description = "Vikinge markede Lindholm Høje. Marked med levende vikinger og salgsboder.", 
                    Date = new DateOnly(2024, 06, 27),
                    CategoryId = 1,
                    ImageUrl = ""
                }
                );

            modelBuilder.Entity<Calender>().HasData(
                new Calender
                {
                    Id = 1,
                    Title = "Tylstrup Middelalder Marked",
                    Description = "Markedet hvor der vises håndværk fra gammle tider og sælges ting",
                    Date = new DateOnly(2024, 05, 08),
                    CategoryId = 1,
                },
                new Calender
                {
                    Id = 2,
                    Title = "Lindholm Marked",
                    Description = "Vikinge markede Lindholm Høje. Marked med levende vikinger og salgsboder.",
                    Date = new DateOnly(2024, 06, 27),
                    CategoryId = 1,
                }
                );
        }
    }
}
