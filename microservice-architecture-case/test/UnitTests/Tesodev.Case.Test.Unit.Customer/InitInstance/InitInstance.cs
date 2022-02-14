using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tesodev.Case.Customer.Infrastructure;

namespace Tesodev.Case.Test.Unit.Customer.InitInstance
{
    public  static class InitInstance
    {
        public static CustomerDbContext InitCustomerDbContextWithInMemoryCache()
        {
            var options = new DbContextOptionsBuilder<CustomerDbContext>().UseInMemoryDatabase(databaseName: "customer").Options;

            var context = new CustomerDbContext(options);

            return context;
        }
    }
}
