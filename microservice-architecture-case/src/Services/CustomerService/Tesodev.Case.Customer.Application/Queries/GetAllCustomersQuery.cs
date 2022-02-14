using System.Collections.Generic;
using MediatR;
using Tesodev.Case.Customer.Application.Dto;
using Tesodev.Case.Shared.Dtos;

namespace Tesodev.Case.Customer.Application.Queries
{
    public class GetAllCustomersQuery : IRequest<Response<List<CustomerDto>>>
    {
        
    }
}