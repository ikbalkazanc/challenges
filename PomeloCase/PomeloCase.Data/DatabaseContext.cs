using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PomeloCase.Core.Entites;
using PomeloCase.Core.Entities;

namespace PomeloCase.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>();
            modelBuilder.Entity<Post>();
            modelBuilder.Entity<PostsCategories>().HasKey(x => x.Id);
            modelBuilder.Entity<PostViews>().HasKey(x => x.Id);
            modelBuilder.Entity<User>();
        }
    }
}
