using Microsoft.EntityFrameworkCore;
using Tesodev.Case.Order.Domain.OrderAggregate;

namespace Tesodev.Case.Order.Infrastructure
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Domain.OrderAggregate.Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.OrderAggregate.Order>().OwnsOne(o => o.Address).WithOwner();
            base.OnModelCreating(modelBuilder);
        }
    }
}