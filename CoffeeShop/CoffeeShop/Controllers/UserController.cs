using AutoMapper;
using CoffeeShop.Core.Commands.Users;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Queries.Addresses;
using CoffeeShop.Core.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    [Route("")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public IActionResult Index()
        {
            return View();
        }
        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _mediator.Send(new GetUsersQuery());
            return Ok(_mapper.Map<List<UserDTO>>(result));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery { UserId = id });
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<UserDTO>(result));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(string firstName, string lastName, string email, string password, int addressId)
        {
            var result = await _mediator.Send(new CreateUserCommand
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                Address = await _mediator.Send(new GetAddressByIdQuery { Id = addressId })
            });
            var user = _mapper.Map<UserDTO>(result);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }
    }
}
