using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tesodev.Case.Order.Application.Commands;
using Tesodev.Case.Order.Infrastructure;
using Tesodev.Case.Shared.Dtos;

namespace Tesodev.Case.Order.Application.Handlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Response<bool>>
    {
        private readonly OrderDbContext _context;

        public UpdateOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Response<bool>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var order = await _context.Orders.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id);
            if (order == default) return response.AddError("order not found");

            order.Quantity = request.Quantity;
            order.Status = request.Status;
            order.Price = request.Price;
            order.Address.AddressLine = request.Address.AddressLine;
            order.Address.Country = request.Address.Country;
            order.Address.CityCode = request.Address.CityCode;
            order.Address.City = request.Address.City;

            _context.Orders.Update(order);
            _context.SaveChanges();

            return response.Success(true);
        }
    }
}