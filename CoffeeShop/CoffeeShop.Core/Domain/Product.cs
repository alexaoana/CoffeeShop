using CoffeeShop.Core.Domain;
using CoffeeShop.Core.Enums;
using System.ComponentModel.DataAnnotations;

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
            get
            {
                return Amount;
            }
            set
            {
                if (value > 0)
                    Amount = value;
            }
        }
        [Required]
        public decimal Price { 
            get
            {
                return Price;
            }
            set
            {
                if (value > 0)
                    Price = value;
            }
        }
        [Required]
        public ProductUnit ProductUnit { get; set; }
        public List<ProductOrder>? ProductOrders { get; set; }
        public Image Image { get; set; }
        [Required]
        public int CoffeeIntensity
        {
            get
            {
                return CoffeeIntensity;
            }
            set
            {
                if (value > 0)
                    CoffeeIntensity = value;
            }
        }
        public Product(int id, string name, string description, int amount, decimal price, ProductUnit productUnit, Image image, int coffeeIntensity)
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
        public Product(string name, string description, int amount, decimal price, ProductUnit productUnit, Image image, int coffeeIntensity)
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
        public Product(string name, int amount, decimal price, ProductUnit productUnit, Image image, int coffeeIntensity)
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
