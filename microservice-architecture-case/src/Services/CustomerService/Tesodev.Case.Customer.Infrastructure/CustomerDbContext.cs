using Microsoft.EntityFrameworkCore;

namespace Tesodev.Case.Customer.Infrastructure
{
    public class CustomerDbContext:DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Domain.CustomerAggregate.Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.CustomerAggregate.Customer>().ToTable("Customer");
            modelBuilder.Entity<Domain.CustomerAggregate.Customer>().OwnsOne(o => o.Address).WithOwner();

            base.OnModelCreating(modelBuilder);
        }
    }
}