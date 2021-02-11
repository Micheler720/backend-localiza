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
        
        public DbSet<User> Users { get; set; }
    }
}