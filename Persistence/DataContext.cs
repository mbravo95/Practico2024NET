using Microsoft.EntityFrameworkCore;
using Practico2024NET.Domain;

namespace Practico2024NET.Persistence
{
    public class DataContext : DbContext
    {
        public DbSet<Sport> sports { get; set; }
        public DbSet<Confederacy> confederacies { get; set; }
        public DbSet<Country> countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("pencaDb");
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sport>().HasData(
                new Sport
                {
                    id = 1,
                    name = "Futbol"
                }, new Sport
                {
                    id = 2,
                    name = "Basquet"
                }, new Sport
                {
                    id = 3,
                    name = "Tenis"
                });

            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    id = 1,
                    name = "Uruguay"
                }, new Country
                {
                    id = 2,
                    name = "Argentina"
                }, new Country
                {
                    id = 3,
                    name = "Brasil"
                });

            modelBuilder.Entity<Confederacy>().HasData(
                new Confederacy
                {
                    id = 1,
                    name = "UEFA",
                    creation_date = DateTime.Now
                }, new Confederacy
                {
                    id = 2,
                    name = "CONMEBOL",
                    creation_date = DateTime.Now
                }, new Confederacy
                {
                    id = 3,
                    name = "CONCACAF",
                    creation_date = DateTime.Now
                });

            base.OnModelCreating(modelBuilder);
        }

    }
}
