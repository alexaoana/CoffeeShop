using CoffeeShop.Core.Commands.Products;
using CoffeeShop.Core.Patterns.Decorator;
using MediatR;

namespace CoffeeShop.Core.CommandHandlers.Products
{
    public class CreateCustomProductCommandHandler : IRequestHandler<CreateCustomProductCommand, bool>
    {
        public async Task<bool> Handle(CreateCustomProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Product;
            foreach (var ingredient in request.Ingredients)
                switch (ingredient)
                {
                    case "milk":
                        product = new CoffeeWithMilk(product).GetProduct();
                        break;
                    case "almond milk":
                        product = new CoffeeWithAlmondMilk(product).GetProduct();
                        break;
                    case "coconut milk":
                        product = new CoffeeWithCoconutMilk(product).GetProduct();
                        break;
                    case "caffeine":
                        product = new CoffeeWithCaffeine(product).GetProduct();
                        break;
                    case "no caffeine":
                        product = new CoffeeWithoutCaffeine(product).GetProduct();
                        break;
                    case "sugar":
                        product = new CoffeeWithSugar(product).GetProduct();
                        break;
                    case "cream":
                        product = new CoffeeWithCream(product).GetProduct();
                        break;
                    case "ice":
                        product = new CoffeeWithIce(product).GetProduct();
                        break;
                }
            return true;
        }
    }
}
