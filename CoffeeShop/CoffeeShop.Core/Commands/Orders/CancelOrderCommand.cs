using CoffeeShop.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Commands.Orders
{
    public class CancelOrderCommand : IRequest<OrderDTO>
    {
        public int OrderId { get; set; }
    }
}
