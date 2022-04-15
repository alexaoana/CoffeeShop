using CoffeeShop.Core.Abstract.Patterns;
using MediatR;

namespace CoffeeShop.Core.Commands.Orders
{
    public class PayOrderCommand : IRequest<bool>
    {
        public int OrderId { get; set; }
        public Payment Payment { get; set; }
    }
}
