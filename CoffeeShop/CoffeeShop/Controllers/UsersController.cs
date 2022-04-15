using AutoMapper;
using CoffeeShop.Core;
using CoffeeShop.Core.Commands.Users;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Queries.Orders;
using CoffeeShop.Core.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            return Ok(users);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery { UserId = id });
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]UserDTO userDTO)
        {
            var user = await _mediator.Send(new CreateUserCommand
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Address = new Address(userDTO.AddressCity, userDTO.AddressStreet, userDTO.AddressNumber)
            });
            
            return CreatedAtAction(nameof(GetUserById), new { id = _mapper.Map<UserDTO, User>(user).Id }, user);
        }

        [HttpGet]
        [Route("{id}/orders")]
        public async Task<IActionResult> GetOrdersOfUser(int id)
        {
            var orders = await _mediator.Send(new GetOrdersOfUserQuery { UserId = id });
            if (orders == null)
                return NotFound();
            return Ok(orders);
        }
    }
}
