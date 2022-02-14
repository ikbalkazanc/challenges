using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Tesodev.Case.Order.Application.Commands;
using Tesodev.Case.Order.Application.Dto;
using Tesodev.Case.Order.Application.Queries;
using Tesodev.Case.Shared.Dtos;

namespace Tesodev.Case.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<Response<List<OrderDto>>> GetAll()
        {
            return _mediator.Send(new GetAllOrderQuery());
        }
        [HttpGet("{id}")]
        public Task<Response<OrderDto>> GetByOrderId([FromRoute] Guid id)
        {
            return _mediator.Send(new GetOrderByOrderIdQuery(id));
        }
        [HttpGet("customerorders/{customerid}")]
        public Task<Response<List<OrderDto>>> GetByCustomerId([FromRoute] Guid customerid)
        {
            return _mediator.Send(new GetOrdersByCustomerIdQuery(customerid));
        }

        [HttpPost]
        public Task<Response<OrderDto>> Create(CreateOrderCommand request)
        {
            return _mediator.Send(request);
        }
        [HttpPut]
        public Task<Response<bool>> Update(UpdateOrderCommand request)
        {
            return _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public Task<Response<bool>> Delete([FromRoute] Guid id)
        {
            return _mediator.Send(new DeleteOrderCommand(id));
        }

        [HttpPost("changestatus")]
        public Task<Response<bool>> CahangeStatus([FromBody] ChangeStatusOrderCommand request)
        {
            return _mediator.Send(request);
        }
    }
}
