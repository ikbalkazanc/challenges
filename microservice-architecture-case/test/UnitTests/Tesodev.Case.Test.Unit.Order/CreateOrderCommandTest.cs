using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Tesodev.Case.FastHttpClient;
using Tesodev.Case.Order.Application.Commands;
using Tesodev.Case.Order.Application.Dto;
using Tesodev.Case.Order.Application.Handlers;
using Tesodev.Case.Order.Infrastructure;
using Tesodev.Case.Shared.Dtos;
using Xunit;

namespace Tesodev.Case.Test.Unit.Order
{
    public class CreateOrderCommandTest
    {
        private readonly CreateOrderCommandHandler _handler;
        private OrderDbContext _context;
        private Mock<HttpRequest> _httpMock;

        public CreateOrderCommandTest()
        {
            _context = InitInstance.InitInstance.InitOrderDbContextWithInMemoryCache();
            _handler = new CreateOrderCommandHandler(_context);
            _httpMock = new Mock<HttpRequest>();
        }

        [Fact]
        public void CreateOrderCommand_SuccessfullyInsert_ReturnSuccessfulResponse()
        {

            var command = new CreateOrderCommand()
            {
                CustomerId = Guid.NewGuid(),
                Quantity = 1,
                Price = 1,
                Status = "in-way",
                Address = new AddressDto()
                {
                    AddressLine = "FASFAS",
                    Country = "ASD",
                    CityCode = 1,
                    City = "ASD"
                },
                ProductId =  Guid.NewGuid()
            };

            var result = _handler.Handle(command, CancellationToken.None).Result;

            Assert.Equal(result.Errors, null);
            Assert.NotEqual(result.Data, null);

        }

        [Fact]
        public void CreateOrderCommand_CustomerNotValid_ReturnCustomerNotValidErrorResponse()
        {

            var command = new CreateOrderCommand()
            {
                CustomerId = Guid.NewGuid(),
                Quantity = 1,
                Price = 1,
                Status = "in-way",
                Address = new AddressDto()
                {
                    AddressLine = "FASFAS",
                    Country = "ASD",
                    CityCode = 1,
                    City = "ASD"
                },
                ProductId = Guid.NewGuid()
            };

            var result = _handler.Handle(command, CancellationToken.None).Result;

            Assert.Equal(result.Errors, null);
            Assert.NotEqual(result.Data, null);

        }
    }
}