using Microsoft.EntityFrameworkCore;
using MyBackend.Models;

namespace MyBackend.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        /*public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDb")
                 .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name },
                 Microsoft.Extensions.Logging.LogLevel.Information).EnableSensitiveDataLogging();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>().HasMany(e => e.Courses).WithMany(s => s.Students)
               .UsingEntity<Enrollment>(es => es.HasOne<Course>().WithMany(),
               bs => bs.HasOne<Student>().WithMany());

            modelBuilder.Entity<Katalog>().HasMany(e => e.Produks).WithMany(s => s.Katalogs)
               .UsingEntity<KatalogProduk>(es => es.HasOne<Produk>().WithMany(),
               bs => bs.HasOne<Katalog>().WithMany());

        }*/

    }
}
