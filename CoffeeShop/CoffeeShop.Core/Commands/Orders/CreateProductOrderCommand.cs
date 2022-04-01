using MediatR;

namespace CoffeeShop.Core.Commands.Orders
{
    public class CreateProductOrderCommand : IRequest<bool>
    {
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
    }
}
