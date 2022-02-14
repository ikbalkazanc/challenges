using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Tesodev.Case.Customer.Application.Dto;
using Tesodev.Case.Shared.Dtos;

namespace Tesodev.Case.Customer.Application.Queries
{
    public class GetCustomerQuery : IRequest<Response<CustomerDto>>
    {
        public GetCustomerQuery(Guid id)
        {
            Id = id;
        }

        [Required] public Guid Id { get; set; }
    }
}