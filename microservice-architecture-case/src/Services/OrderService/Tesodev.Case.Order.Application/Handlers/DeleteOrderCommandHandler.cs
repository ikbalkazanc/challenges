using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tesodev.Case.Order.Application.Commands;
using Tesodev.Case.Order.Infrastructure;
using Tesodev.Case.Shared.Dtos;

namespace Tesodev.Case.Order.Application.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Response<bool>>
    {
        private readonly OrderDbContext _context;

        public DeleteOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public  async Task<Response<bool>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();


            var order = await _context.Orders.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.OrderId);
            if (order == default) return response.AddError("order not found");

            order.IsDeleted = true;

            _context.Orders.Update(order);
            _context.SaveChanges();

            return response.Success(true);
        }
    }
}