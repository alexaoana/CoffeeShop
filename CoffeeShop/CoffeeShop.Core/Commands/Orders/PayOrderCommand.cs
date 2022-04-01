using CoffeeShop.Core.Abstract.Patterns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Commands.Orders
{
    public class PayOrderCommand : IRequest<bool>
    {
        public Order Order { get; set; }
        public Payment Payment { get; set; }
    }
}
