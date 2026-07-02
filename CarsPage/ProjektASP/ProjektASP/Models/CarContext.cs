using Microsoft.EntityFrameworkCore;

namespace ProjektASP.Models {
    public class CarContext : DbContext {
        public CarContext(DbContextOptions<CarContext> options) : base(options) {
        }

        public DbSet<Owner> Owner { get; set; }
        public DbSet<Car> Car { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //Owner
            modelBuilder.Entity<Owner>().HasKey(s => s.Id);
            modelBuilder.Entity<Owner>(entity => {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.DateOfBirth)
                    .IsRequired();
            });

            //Car
            modelBuilder.Entity<Car>().HasKey(s => s.Id);
            modelBuilder.Entity<Car>()
                .HasOne(e => e.Owner_R)
                .WithMany(e => e.Car_R)
                .HasForeignKey(e => e.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Car>(entity => {
                entity.Property(e => e.OwnerId);

                entity.Property(e => e.Mark)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.YearOfProduction)
                    .IsRequired();

                entity.Property(e => e.Plate)
                      .IsRequired()
                      .HasMaxLength(9);

                modelBuilder.Entity<Car>()
                    .HasIndex(e => new { e.Plate })
                    .IsUnique();
            });
        }
    }
}
