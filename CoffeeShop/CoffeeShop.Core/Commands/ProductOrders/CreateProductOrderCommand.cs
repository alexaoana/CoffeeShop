using CoffeeShop.Core.DTOs;
using MediatR;

namespace CoffeeShop.Core.Commands.ProductOrders
{
    public class CreateProductOrderCommand : IRequest<ProductOrderDTO>
    {
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
    }
}
