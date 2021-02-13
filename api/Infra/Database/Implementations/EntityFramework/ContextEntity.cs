using Microsoft.EntityFrameworkCore;
using Entities.Interfaces;
using Entities;

namespace Infra.Database.Implementations.EntityFramework
{
    public class ContextEntity : DbContext
    {

        public ContextEntity() { }
        public ContextEntity(DbContextOptions options)
        : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=localiza;Uid=sa;Pwd=Administr@dor1");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Brand)
                .WithMany(b => b.Cars)
                .HasForeignKey(c => c.IdBrand);
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Category)
                .WithMany(b => b.Cars)
                .HasForeignKey(c => c.IdCategory);
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Fuel)
                .WithMany(b => b.Cars)
                .HasForeignKey(c => c.IdFuel);
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Model)
                .WithMany(b => b.Cars)
                .HasForeignKey(c => c.IdModel);
        }
        public DbSet<Car> Cars { get; set;}        
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Client> Clients { get; set; }        
        public DbSet<IUser> Users { get; set; }        
        public DbSet<CarBrand> car_brands { get; set; }
        public DbSet<CarCategory> car_categories { get; set;}
        public DbSet<CarFuel> car_fuels { get; set;}
        public DbSet<CarModel> car_models { get; set;}

    }
}