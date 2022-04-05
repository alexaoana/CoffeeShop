using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Commands.Orders
{
    public class GetTotalPricePerOrderCommand : IRequest<decimal>
    {
        public Order Order { get; set; }
    }
}
