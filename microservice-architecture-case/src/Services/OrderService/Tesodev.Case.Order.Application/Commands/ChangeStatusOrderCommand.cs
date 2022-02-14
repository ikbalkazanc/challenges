using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Tesodev.Case.Shared.Dtos;

namespace Tesodev.Case.Order.Application.Commands
{
    public class ChangeStatusOrderCommand : IRequest<Response<bool>>
    {

        [Required] public Guid OrderId { get; set; }
        [Required] public string Status { get; set; }
    }
}