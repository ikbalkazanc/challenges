using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tesodev.Case.Customer.Application.Commands;
using Tesodev.Case.Customer.Application.Dto;
using Tesodev.Case.Customer.Infrastructure;
using Tesodev.Case.Shared.Dtos;
using Tevodev.Case.Customer.Application.Mapping;

namespace Tesodev.Case.Customer.Application.Handlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<CreatedOrUpdatedCustomerDto>>
    {
        private readonly CustomerDbContext _context;

        public CreateCustomerCommandHandler(CustomerDbContext context)
        {
            _context = context;
        }
        public async Task<Response<CreatedOrUpdatedCustomerDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<CreatedOrUpdatedCustomerDto>();
            var customer = ObjectMapper.Mapper.Map<Domain.CustomerAggregate.Customer>(request);

            customer.Id = Guid.NewGuid();
            customer.CreatedAt = DateTime.UtcNow;

            _context.Add(customer);
            _context.SaveChanges();

            response.Data.CustomerId = customer.Id;
            return response;
        }
    }
}