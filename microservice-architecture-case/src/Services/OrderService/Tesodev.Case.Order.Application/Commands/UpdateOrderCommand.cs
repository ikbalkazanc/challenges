using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MediatR;
using Tesodev.Case.Order.Application.Dto;
using Tesodev.Case.Shared.Dtos;

namespace Tesodev.Case.Order.Application.Commands
{
    public class UpdateOrderCommand : IRequest<Response<bool>>
    {
        [Required] public Guid Id { get; set; }
        [Required] public int Quantity { get; set; }
        [Required] public double Price { get; set; }
        [Required] public string Status { get; set; }
        [Required] public AddressDto Address { get; set; }
    }
}