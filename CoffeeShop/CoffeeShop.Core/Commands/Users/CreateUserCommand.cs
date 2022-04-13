using CoffeeShop.Core.DTOs;
using MediatR;

namespace CoffeeShop.Core.Commands.Users
{
    public class CreateUserCommand : IRequest<UserDTO>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
    }
}