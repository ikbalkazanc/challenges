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
    public class GetOrderByOrderIdQueryHandler : IRequestHandler<GetOrderByOrderIdQuery, Response<OrderDto>>
    {
        private readonly OrderDbContext _context;

        public GetOrderByOrderIdQueryHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Response<OrderDto>> Handle(GetOrderByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<OrderDto>();

            var order = await _context.Orders.Where(x => !x.IsDeleted && x.Id == request.OrderId).Join(_context.Products.Where(x => !x.IsDeleted),
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
                }).FirstOrDefaultAsync();


            return response.Success(order);
        }
    }
}