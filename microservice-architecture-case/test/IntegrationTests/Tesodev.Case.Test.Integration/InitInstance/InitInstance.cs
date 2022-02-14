using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tesodev.Case.Customer.Infrastructure;
using Tesodev.Case.Order.Infrastructure;

namespace Tesodev.Case.Test.Integration.InitInstance
{
    public  static class InitInstance
    {
        public static CustomerDbContext InitCustomerDbContextWithInMemoryCache()
        {
            var options = new DbContextOptionsBuilder<CustomerDbContext>().UseInMemoryDatabase(databaseName: "customer").Options;

            var context = new CustomerDbContext(options);

            return context;
        }
        public static OrderDbContext InitOrderDbContextWithInMemoryCache()
        {
            var options = new DbContextOptionsBuilder<OrderDbContext>().UseInMemoryDatabase(databaseName: "order").Options;

            var context = new OrderDbContext(options);

            return context;
        }
    }
}
