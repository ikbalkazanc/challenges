using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Tesodev.Case.Customer.Application.Dto;
using Tesodev.Case.Shared.Dtos;

namespace Tesodev.Case.Customer.Application.Queries
{
    public class ValidateCustomerQuery : IRequest<Response<bool>>
    {
        public ValidateCustomerQuery(Guid customerid)
        {
            CustomerId = customerid;
        }

        [Required] public Guid CustomerId { get; set; }
    }
}