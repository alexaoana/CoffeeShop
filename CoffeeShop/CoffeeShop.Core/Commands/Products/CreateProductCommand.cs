using CoffeeShop.Core.Domain;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Enums;
using MediatR;

namespace CoffeeShop.Core.Commands.Products
{
    public class CreateProductCommand : IRequest<ProductDTO>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public ProductUnit ProductUnit { get; set; }
        public int CoffeeIntensity { get; set; }
    }
}
