using System.Security.Cryptography.X509Certificates;
using Coredet.Core.Entities;
using Coredet.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace Coredet.Data
{
    public class CoredetContext : DbContext
    {
        public CoredetContext(DbContextOptions<CoredetContext> options) : base(options)
        {
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<User>();
            modelBuilder.Entity<Basket>();
            modelBuilder.Entity<BasketProducts>();
            modelBuilder.Entity<Product>();

            modelBuilder.ApplyConfiguration(new UserSeed());
            modelBuilder.ApplyConfiguration(new ProductSeed());

            base.OnModelCreating(modelBuilder);
        }

    }
}