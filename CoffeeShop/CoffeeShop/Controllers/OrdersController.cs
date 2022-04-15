using AutoMapper;
using CoffeeShop.Core;
using CoffeeShop.Core.Commands.Orders;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Patterns.Strategy;
using CoffeeShop.Core.Queries.Orders;
using CoffeeShop.Core.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IMapper _mapper;
        private IMediator _mediator;
        public OrdersController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = _mediator.Send(new GetOrderByIdQuery{ OrderId = id });
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody]int userId)
        {
            var order = await _mediator.Send(new CreateOrderCommand
            {
                UserId = userId
            });
            return CreatedAtAction(nameof(GetOrderById), new { Id = _mapper.Map<OrderDTO, Order>(order).Id }, order);
        }

        [HttpPut]
        public async Task<IActionResult> PayOrder([FromBody]int orderId)
        {
            var result = await _mediator.Send(new PayOrderCommand
            {
                OrderId = orderId,
                Payment = new PayByCash()
            });
            return Ok(result);
        }

    }
}
