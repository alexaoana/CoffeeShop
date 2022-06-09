using CoffeeShop.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Commands.Users
{
    public class GetCurrentOrderOfUserCommand : IRequest<OrderDTO>
    {
        public int UserId { get; set; }
    }
}
