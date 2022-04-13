using AutoMapper;
using CoffeeShop.Core.Commands.Products;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Enums;
using CoffeeShop.Core.Patterns.Decorator;
using MediatR;

namespace CoffeeShop.Core.CommandHandlers.Products
{
    public class CreateCustomProductCommandHandler : IRequestHandler<CreateCustomProductCommand, ProductDTO>
    {
        private IMapper _mapper;
        public CreateCustomProductCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ProductDTO> Handle(CreateCustomProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Product;
            foreach (var ingredient in request.Ingredients)
                switch (ingredient)
                {
                    case Ingredient.Milk:
                        product = new CoffeeWithMilk(product).GetProduct();
                        break;
                    case Ingredient.AlmondMilk:
                        product = new CoffeeWithAlmondMilk(product).GetProduct();
                        break;
                    case Ingredient.CoconutMilk:
                        product = new CoffeeWithCoconutMilk(product).GetProduct();
                        break;
                    case Ingredient.Caffeine:
                        product = new CoffeeWithCaffeine(product).GetProduct();
                        break;
                    case Ingredient.NoCaffeine:
                        product = new CoffeeWithoutCaffeine(product).GetProduct();
                        break;
                    case Ingredient.Sugar:
                        product = new CoffeeWithSugar(product).GetProduct();
                        break;
                    case Ingredient.Cream:
                        product = new CoffeeWithCream(product).GetProduct();
                        break;
                    case Ingredient.Ice:
                        product = new CoffeeWithIce(product).GetProduct();
                        break;
                }
            return _mapper.Map<Product, ProductDTO>(product);
        }
    }
}
