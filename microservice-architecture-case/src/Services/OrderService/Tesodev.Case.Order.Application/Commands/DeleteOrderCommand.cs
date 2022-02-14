using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Tesodev.Case.Order.Application.Dto;
using Tesodev.Case.Shared.Dtos;

namespace Tesodev.Case.Order.Application.Commands
{
    public class DeleteOrderCommand : IRequest<Response<bool>>
    {
        public DeleteOrderCommand(Guid orderId)
        {
            OrderId = orderId;
        }

        [Required]  public Guid OrderId { get; set; }
    }
}