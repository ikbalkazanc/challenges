using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tesodev.Case.Order.Application.Dto;
using Tesodev.Case.Order.Application.Queries;
using Tesodev.Case.Order.Infrastructure;
using Tesodev.Case.Shared.Dtos;

namespace Tesodev.Case.Order.Application.Handlers
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, Response<List<OrderDto>>>
    {
        private readonly OrderDbContext _context;

        public GetAllOrderQueryHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<OrderDto>>> Handle(GetAllOrderQuery request,
            CancellationToken cancellationToken)
        {
            var response = new Response<List<OrderDto>>();

            var orders = await _context.Orders.Where(x => !x.IsDeleted).Join(_context.Products.Where(x => !x.IsDeleted),
                x => x.ProductId, y => y.Id, (order, product) => new OrderDto()
                {
                    CustomerId = order.CustomerId,
                    Quantity = order.Quantity,
                    Price = order.Price,
                    Status = order.Status,
                    Address = new AddressDto()
                    {
                        City = order.Address.City,
                        CityCode = order.Address.CityCode,
                        Country = order.Address.Country,
                        AddressLine = order.Address.AddressLine
                    },
                    Product = new ProductDto()
                    {
                        IamgeUrl = product.IamgeUrl,
                        Name = product.Name
                    }
                }).ToListAsync();


            return response.Success(orders);
        }
    }
}