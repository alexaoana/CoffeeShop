using MediatR;

namespace CoffeeShop.Core.Commands.Orders
{
    public class CreateOrderCommand : IRequest<bool>
    {
        public User User { get; set; }
    }
}
