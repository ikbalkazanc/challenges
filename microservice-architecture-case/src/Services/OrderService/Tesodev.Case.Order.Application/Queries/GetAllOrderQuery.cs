using System.Collections.Generic;
using MediatR;
using Tesodev.Case.Customer.Application.Dto;
using Tesodev.Case.Order.Application.Dto;
using Tesodev.Case.Shared.Dtos;

namespace Tesodev.Case.Order.Application.Queries
{
    public class GetAllOrderQuery : IRequest<Response<List<OrderDto>>>
    {
        
    }
}