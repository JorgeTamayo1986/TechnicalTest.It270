using Microsoft.EntityFrameworkCore;

namespace TechnicalTest.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }


        public DbSet<Race> Race { get; set; }
        public DbSet<Animal> Animal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Race>();

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(450);

                entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)");
            });
        }



    }
}
