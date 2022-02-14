using System;
using System.Threading;
using Tesodev.Case.Customer.Application.Commands;
using Tesodev.Case.Customer.Application.Dtos;
using Tesodev.Case.Customer.Application.Handlers;
using Tesodev.Case.Customer.Infrastructure;
using Tesodev.Case.Order.Application.Commands;
using Tesodev.Case.Order.Application.Handlers;
using Tesodev.Case.Order.Infrastructure;
using Xunit;

namespace Tesodev.Case.Test.Integration
{
    public class CreateCustomerAndBuyOrderIntegrationTest
    {
        private readonly CreateCustomerCommandHandler _customerHandler;
        private readonly CreateOrderCommandHandler _orderHandler;
        private CustomerDbContext _customerContext;
        private OrderDbContext _orderContext;
        public CreateCustomerAndBuyOrderIntegrationTest()
        {
            _customerContext = InitInstance.InitInstance.InitCustomerDbContextWithInMemoryCache();
            _orderContext = InitInstance.InitInstance.InitOrderDbContextWithInMemoryCache();
            _customerHandler = new CreateCustomerCommandHandler(_customerContext);
            _orderHandler = new CreateOrderCommandHandler(_orderContext);
        }
        [Fact]
        public void TeCreateCustomerAndBuyOrderIntegrationTestst()
        {
            var create_customer_command = new CreateCustomerCommand()
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
            var customerid = _customerHandler.Handle(create_customer_command, CancellationToken.None).Result.Data.CustomerId;

            Assert.NotEqual(customerid, default);

            var create_order_command = new CreateOrderCommand()
            {
                CustomerId = Guid.NewGuid(),
                Quantity = 1,
                Price = 1,
                Status = "in-way",
                Address = new Order.Application.Dto.AddressDto()
                {
                    AddressLine = "FASFAS",
                    Country = "ASD",
                    CityCode = 1,
                    City = "ASD"
                },
                ProductId = Guid.NewGuid()
            };

            var result = _orderHandler.Handle(create_order_command, CancellationToken.None).Result;

            Assert.Equal(result.Errors, null);
            Assert.NotEqual(result.Data, null);
        }
    }
}
