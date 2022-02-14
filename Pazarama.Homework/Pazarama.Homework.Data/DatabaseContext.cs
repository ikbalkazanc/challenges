using Microsoft.EntityFrameworkCore;
using Pazarama.Homework.Core.Entity;

namespace Pazarama.Homework.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }
       
    }
}