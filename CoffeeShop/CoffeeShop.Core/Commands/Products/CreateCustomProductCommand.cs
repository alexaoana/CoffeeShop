using CoffeeShop.Core.Enums;
using MediatR;

namespace CoffeeShop.Core.Commands.Products
{
    public class CreateCustomProductCommand : IRequest<bool>
    {
        public Product Product { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
