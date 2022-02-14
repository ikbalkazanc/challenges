using System;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Tesodev.Case.Customer.API.Controllers;
using Tesodev.Case.Customer.Application.Commands;
using Tesodev.Case.Customer.Application.Dtos;
using Tesodev.Case.Customer.Application.Handlers;
using Tesodev.Case.Customer.Infrastructure;
using Xunit;

namespace Tesodev.Case.Test.Unit.Customer
{
    public class CreateCustomerTest
    {
        private readonly CreateCustomerCommandHandler _handler;
        private CustomerDbContext _context;
        public CreateCustomerTest()
        {
            _context = InitInstance.InitInstance.InitCustomerDbContextWithInMemoryCache();
            _handler = new CreateCustomerCommandHandler(_context);
        }
        [Fact]
        public void CreateCustomerCommand_SuccessfullyInsert_ReturnSuccessfulResponse()
        {
            var command = new CreateCustomerCommand()
            {
                Email = "test@test.com",
                Name = "asdsa",
                Address = new AddressDto()
                {
                    AddressLine = "FASFAS",
                    Country = "ASD",
                    CityCode = 1,
                    City = "ASD"
                }
            };
            var result = _handler.Handle(command, CancellationToken.None).Result;

            Assert.Equal(result.Errors,null);
            Assert.NotEqual(result.Data.CustomerId, default);

            var customer = _context.Customers.FirstOrDefault(x => x.Id == result.Data.CustomerId);
            
            Assert.NotEqual(customer,null);
        }
    }
}
