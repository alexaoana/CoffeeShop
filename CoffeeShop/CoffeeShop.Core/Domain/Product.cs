using CoffeeShop.Core.Domain;
using CoffeeShop.Core.Enums;

namespace CoffeeShop.Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
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
        public ProductUnit ProductUnit { get; set; }
        public List<ProductOrder>? ProductOrders { get; set; }
        public Image Image { get; set; }
        public int CoffeeIntensity { get; set; }
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
