using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tesodev.Case.FastHttpClient;
using Tesodev.Case.FastHttpClient.Enums;
using Tesodev.Case.Order.Application.Dto;
using Tesodev.Case.Order.Application.Queries;
using Tesodev.Case.Order.Infrastructure;
using Tesodev.Case.Shared.Constant;
using Tesodev.Case.Shared.Dtos;

namespace Tesodev.Case.Order.Application.Handlers
{
    public class GetOrdersByCustomerIdQueryHandler : IRequestHandler<GetOrdersByCustomerIdQuery, Response<List<OrderDto>>>
    {
        private readonly OrderDbContext _context;

        public GetOrdersByCustomerIdQueryHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<OrderDto>>> Handle(GetOrdersByCustomerIdQuery request, CancellationToken cancellationToken)
        {
             var response = new Response<List<OrderDto>>();

             var req = new HttpRequest(ServiceUrls.Customer + "validate/" + request.CustomerId.ToString())
                 .SetHttpMethod(HttpMethodTypes.POST).SetDataFormat(HttpDataFormatTypes.Json);

             var customerIsValidate = await req.ExecuteAsync<Response<bool>>();

             if (!customerIsValidate.Data) return response.AddError("Customer not found");

            var orders = await _context.Orders.Where(x => !x.IsDeleted && x.CustomerId == request.CustomerId).Join(_context.Products.Where(x => !x.IsDeleted),
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