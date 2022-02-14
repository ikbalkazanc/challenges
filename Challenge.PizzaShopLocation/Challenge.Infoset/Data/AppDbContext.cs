using Challenge.Infoset.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Infoset.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestaurantBranches>().HasKey(x => x.Id);
            modelBuilder.Entity<RestaurantBranches>().ToTable("restaurant_branches");
            modelBuilder.Entity<RestaurantBranches>().Property(x => x.Name).HasMaxLength(100);
        }
    }

   
}
