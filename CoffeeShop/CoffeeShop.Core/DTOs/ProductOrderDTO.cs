using CoffeeShop.Core.Enums;
using System.Text.Json.Serialization;

namespace CoffeeShop.Core.DTOs
{
    public class ProductOrderDTO
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int CoffeeIntensity { get; set; }
        public int Quantity { get; set; }
    }
}
