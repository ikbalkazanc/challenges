using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Tesodev.Case.Customer.Application.Dto;
using Tesodev.Case.Order.Application.Dto;
using Tesodev.Case.Shared.Dtos;

namespace Tesodev.Case.Order.Application.Queries
{
    public class GetOrderByOrderIdQuery : IRequest<Response<OrderDto>>
    {
        public GetOrderByOrderIdQuery(Guid orderId)
        {
            OrderId = orderId;
        }

        [Required] public Guid OrderId { get; set; }
    }
}