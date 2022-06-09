using CoffeeShop.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Commands.ProductOrders
{
    public class DeleteProductOrderCommand : IRequest<bool>
    {
        public int ProductOrderId { get; set; }
    }
}
