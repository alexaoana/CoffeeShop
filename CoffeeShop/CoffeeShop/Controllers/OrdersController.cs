using AutoMapper;
using CoffeeShop.Core;
using CoffeeShop.Core.Commands.Orders;
using CoffeeShop.Core.DTOs;
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
            var user = _mapper.Map<UserDTO, User>(await _mediator.Send(new GetUserByIdQuery
            {
                UserId = userId
            }));
            user.Id = userId;
            var order = await _mediator.Send(new CreateOrderCommand
            {
                User = user
            });
            return CreatedAtAction(nameof(GetOrderById), new { Id = _mapper.Map<OrderDTO, Order>(order).Id }, order);
        }

        [HttpPut]
        public async Task<IActionResult> PayOrder([FromBody]OrderDTO order)
        {
            var result = await _mediator.Send(new PayOrderCommand { Order = _mapper.Map<OrderDTO, Order>(order) });
            return Ok(result);
        }

    }
}
