using CoffeeShop.Core.Abstract.Patterns;
using MediatR;

namespace CoffeeShop.Core.Commands.Orders
{
    public class PayOrderCommand : IRequest<bool>
    {
        public Order Order { get; set; }
        public Payment Payment { get; set; }
    }
}
