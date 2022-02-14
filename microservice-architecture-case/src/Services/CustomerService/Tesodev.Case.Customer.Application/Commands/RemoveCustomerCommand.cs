using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Tesodev.Case.Shared.Dtos;

namespace Tesodev.Case.Customer.Application.Commands
{
    public class RemoveCustomerCommand : IRequest<Response<bool>>
    {
        public RemoveCustomerCommand(Guid id)
        {
            Id = id;
        }

        [Required] public Guid Id { get; set; }
    }
}