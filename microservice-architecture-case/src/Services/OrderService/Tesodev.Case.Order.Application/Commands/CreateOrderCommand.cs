using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MediatR;
using Tesodev.Case.Order.Application.Dto;
using Tesodev.Case.Shared.Dtos;

namespace Tesodev.Case.Order.Application.Commands
{
    public class CreateOrderCommand : IRequest<Response<OrderDto>>
    {
        [Required] public Guid CustomerId { get; set; }
        [Required] public int Quantity { get; set; }
        [Required] public double Price { get; set; }
        [Required] public string Status { get; set; }
        [Required] public AddressDto Address { get; set; }
        [Required] public Guid ProductId { get; set; }
    }
}
