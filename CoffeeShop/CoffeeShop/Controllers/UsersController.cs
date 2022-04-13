using AutoMapper;
using CoffeeShop.Core;
using CoffeeShop.Core.Commands.Addresses;
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
        public async Task<IActionResult> CreateUser(string firstName, string lastName, string email, string password, string addressCity, string addressStreet, string addressNumber)
        {
            var user = await _mediator.Send(new CreateUserCommand
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            });
            var address = await _mediator.Send(new CreateAddressCommand
            {
                City = addressCity,
                Street = addressStreet,
                Number = addressNumber,
                User = _mapper.Map<UserDTO, User>(user)
            });
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpGet]
        [Route("{id}/orders")]
        public async Task<IActionResult> GetOrdersOfUser(int id)
        {
            var user = await _mediator.Send(new GetOrdersOfUserQuery { UserId = id });
            if (user == null)
                return NotFound();
            return Ok(user);
        }
    }
}
