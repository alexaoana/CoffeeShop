using MediatR;

namespace CoffeeShop.Core.Commands.Products
{
    public class CreateCustomProductCommand : IRequest<bool>
    {
        public Product Product { get; set; }
        public List<string> Ingredients { get; set; }
    }
}
