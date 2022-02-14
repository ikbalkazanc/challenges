using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tesodev.Case.Order.Infrastructure;

namespace Tesodev.Case.Test.Unit.Order.InitInstance
{
    public  static class InitInstance
    {
        public static OrderDbContext InitOrderDbContextWithInMemoryCache()
        {
            var options = new DbContextOptionsBuilder<OrderDbContext>().UseInMemoryDatabase(databaseName: "Order").Options;

            var context = new OrderDbContext(options);

            return context;
        }
    }
}
