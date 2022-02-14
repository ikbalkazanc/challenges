using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tesodev.Case.Customer.Application.Dto;
using Tesodev.Case.Customer.Application.Queries;
using Tesodev.Case.Customer.Infrastructure;
using Tesodev.Case.Shared.Dtos;
using Tevodev.Case.Customer.Application.Mapping;

namespace Tesodev.Case.Customer.Application.Handlers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery,Response<List<CustomerDto>>>
    {
        public CustomerDbContext _context;

        public GetAllCustomersQueryHandler(CustomerDbContext context)
        {
            _context = context;
        }
        public async Task<Response<List<CustomerDto>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<CustomerDto>>();
            var customers = await _context.Customers.Where(x => !x.IsDeleted).ToListAsync();
            var customerdto = ObjectMapper.Mapper.Map<List<CustomerDto>>(customers);
            response.Data = customerdto;
            return response;
        }
    }
}