using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoffeeShop.Core
{
    public class ProductOrder
    {
        [Required]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
        [Required]
        public int Quantity { get; set; }
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
        public double Price
        {
            get;
            set;
        }
        [Required]
        public int CoffeeIntensity { get; set; }
        public ProductOrder()
        {

        }
        public ProductOrder(Product product)
        {
            Name = product.Name;
            Description = product.Description;
            Amount = product.Amount;
            Price = product.Price;
            CoffeeIntensity = product.CoffeeIntensity;
        }
        public ProductOrder(int id, int quantity, Product product)
        {
            Id = id;
            Name = product.Name;
            Description = product.Description;
            Amount = product.Amount;
            Price = product.Price;
            CoffeeIntensity= product.CoffeeIntensity;
            Quantity = quantity;
        }
        public ProductOrder(int quantity, Product product)
        {
            Name = product.Name;
            Description = product.Description;
            Amount = product.Amount;
            Price = product.Price;
            CoffeeIntensity = product.CoffeeIntensity;
            Quantity = quantity;
        }
    }
}
