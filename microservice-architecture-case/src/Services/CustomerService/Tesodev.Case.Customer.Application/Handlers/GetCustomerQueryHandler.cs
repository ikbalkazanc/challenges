using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tesodev.Case.Customer.Application.Dto;
using Tesodev.Case.Customer.Application.Queries;
using Tesodev.Case.Customer.Infrastructure;
using Tesodev.Case.Shared.Dtos;
using Tevodev.Case.Customer.Application.Mapping;

namespace Tesodev.Case.Customer.Application.Handlers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Response<CustomerDto>>
    {
        public CustomerDbContext _context;

        public GetCustomerQueryHandler(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<Response<CustomerDto>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<CustomerDto>();

            var customer = _context.Customers.FirstOrDefault(x => !x.IsDeleted && x.Id == request.Id);
            if (customer is null) return response.AddError("Customer not found");

            response.Data = ObjectMapper.Mapper.Map<CustomerDto>(customer);

            return response;
        }
    }
}