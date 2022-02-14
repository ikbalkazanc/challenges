using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Tesodev.Case.Customer.Application.Commands;
using Tesodev.Case.Customer.Application.Dto;
using Tesodev.Case.Customer.Application.Queries;
using Tesodev.Case.Shared.Dtos;

namespace Tesodev.Case.Customer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<Response<List<CustomerDto>>> Get()
        {
            
            return _mediator.Send(new GetAllCustomersQuery());
        } 
        [HttpGet("{id}")]
        public Task<Response<CustomerDto>> Get([FromRoute]Guid id)
        {
            return _mediator.Send(new GetCustomerQuery(id));
        }
        

        [HttpPost]
        public Task<Response<CreatedOrUpdatedCustomerDto>> Create(CreateCustomerCommand request)
        {
            return _mediator.Send(request);
        } 
        [HttpPut]
        public Task<Response<bool>> Update(UpdateCustomerCommand request)
        {
            return _mediator.Send(request);
        }
        
        [HttpDelete("{id}")]
        public Task<Response<bool>> Delete([FromRoute]Guid id)
        {
            return _mediator.Send(new RemoveCustomerCommand(id));
        }
        
        [HttpPost("validate/{customerid}")]
        public Task<Response<bool>> Validate([FromRoute] Guid customerid)
        {
            return _mediator.Send(new ValidateCustomerQuery(customerid));
        }
    }
}