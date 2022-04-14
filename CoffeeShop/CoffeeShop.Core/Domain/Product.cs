using CoffeeShop.Core.Domain;
using CoffeeShop.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoffeeShop.Core
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public int Amount
        {
            get;
            set;
        }
        [Required]
        public double Price {
            get;
            set;
        }
        [Required]
        public ProductUnit ProductUnit { get; set; }
        [JsonIgnore]
        public List<ProductOrder>? ProductOrders { get; set; }
        public Image Image { get; set; }
        [Required]
        public int CoffeeIntensity { get; set; }
        public Product(int id, string name, string description, int amount, double price, ProductUnit productUnit, Image image, int coffeeIntensity)
        {
            Id = id;
            Name = name;
            Description = description;
            Amount = amount;
            Price = price;
            ProductUnit = productUnit;
            Image = image;
            CoffeeIntensity = coffeeIntensity;
            ProductOrders = new List<ProductOrder>();
        }
        public Product(string name, string description, int amount, double price, ProductUnit productUnit, Image image, int coffeeIntensity)
        {
            Name = name;
            Description = description;
            Amount = amount;
            Price = price;
            ProductUnit = productUnit;
            Image = image;
            CoffeeIntensity = coffeeIntensity;
            ProductOrders = new List<ProductOrder>();
        }
        public Product(string name, string description, int amount, double price, ProductUnit productUnit, int coffeeIntensity)
        {
            Name = name;
            Description = description;
            Amount = amount;
            Price = price;
            ProductUnit = productUnit;
            Image = null;
            CoffeeIntensity = coffeeIntensity;
            ProductOrders = new List<ProductOrder>();
        }
        public Product(string name, int amount, double price, ProductUnit productUnit, Image image, int coffeeIntensity)
        {
            Name = name;
            Amount = amount;
            Price = price;
            ProductUnit = productUnit;
            Image = image;
            CoffeeIntensity = coffeeIntensity;
            ProductOrders = new List<ProductOrder>();
        }
        public Product()
        {
            
        }
    }
}
