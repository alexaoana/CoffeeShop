using CoffeeShop.Core.Abstract.Patterns;
using CoffeeShop.Core.DTOs;
using MediatR;

namespace CoffeeShop.Core.Commands.Orders
{
    public class PayOrderCommand : IRequest<OrderDTO>
    {
        public int OrderId { get; set; }
        public Payment Payment { get; set; }
    }
}
