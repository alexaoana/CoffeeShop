using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Enums;
using MediatR;

namespace CoffeeShop.Core.Commands.ProductOrders
{
    public class CreateProductOrderCommand : IRequest<ProductOrderDTO>
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
