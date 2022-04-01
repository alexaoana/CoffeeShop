using CoffeeShop.Core.Domain;
using CoffeeShop.Core.Enums;
using MediatR;

namespace CoffeeShop.Core.Commands.Products
{
    public class AddProductCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public ProductUnit ProductUnit { get; set; }
        public Image Image { get; set; }
        public int CoffeeIntensity { get; set; }
    }
}
