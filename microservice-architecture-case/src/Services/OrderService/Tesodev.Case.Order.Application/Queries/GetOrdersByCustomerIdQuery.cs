using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Tesodev.Case.Customer.Application.Dto;
using Tesodev.Case.Order.Application.Dto;
using Tesodev.Case.Shared.Dtos;

namespace Tesodev.Case.Order.Application.Queries
{
    public class GetOrdersByCustomerIdQuery : IRequest<Response<List<OrderDto>>>
    {
        public GetOrdersByCustomerIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }

        [Required] public Guid CustomerId { get; set; }
    }
}