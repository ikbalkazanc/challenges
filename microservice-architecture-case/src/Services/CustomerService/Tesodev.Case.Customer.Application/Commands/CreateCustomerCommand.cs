using System.ComponentModel.DataAnnotations;
using MediatR;
using Tesodev.Case.Customer.Application.Dto;
using Tesodev.Case.Customer.Application.Dtos;
using Tesodev.Case.Shared.Dtos;

namespace Tesodev.Case.Customer.Application.Commands
{
    public class CreateCustomerCommand : IRequest<Response<CreatedOrUpdatedCustomerDto>>
    {
        [Required] public string Name { get; set; }
        [Required] public string Email { get; set; }
        [Required] public AddressDto Address { get; set; }
    }
}