using CoffeeShop.Core.Domain;
using CoffeeShop.Core.Enums;
using System.Text.Json.Serialization;

namespace CoffeeShop.Core.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public ProductUnit ProductUnit { get; set; }
        public string ImageAzurePath { get; set; }
        public int CoffeeIntensity { get; set; }
    }
}
