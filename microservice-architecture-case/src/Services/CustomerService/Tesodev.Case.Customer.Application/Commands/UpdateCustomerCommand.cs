using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Tesodev.Case.Customer.Application.Dto;
using Tesodev.Case.Customer.Application.Dtos;
using Tesodev.Case.Shared.Dtos;

namespace Tesodev.Case.Customer.Application.Commands
{
    public class UpdateCustomerCommand : IRequest<Response<bool>>
    {
        [Required] public Guid Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public AddressDto Address { get; set; }
    }
}