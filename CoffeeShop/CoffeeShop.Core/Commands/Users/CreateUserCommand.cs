﻿using MediatR;

namespace CoffeeShop.Core.Commands.Users
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Email { get; set; }
        public Address Address { get; set; }
    }
}