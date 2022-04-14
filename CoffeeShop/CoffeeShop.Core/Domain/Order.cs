using CoffeeShop.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoffeeShop.Core
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        [Required]
        public OrderStatus OrderStatus { get; set; }
        public double Price
        {
            get
            {
                return ProductOrders
                    .Aggregate(0.0, (price, productOrder) => price + productOrder.Quantity * productOrder.Product.Price);
            }
        }
        public int NumberOfProducts
        {
            get
            {
                return ProductOrders.Sum(productOrder => productOrder.Quantity);
            }
        }
        public List<ProductOrder>? ProductOrders { get; set; }
        public Order(int id)
        {
            Id = id;
            OrderStatus = OrderStatus.InProgress;
            ProductOrders = new List<ProductOrder>();
        }
        public Order()
        {
            OrderStatus = OrderStatus.InProgress;
            ProductOrders = new List<ProductOrder>();
        }
    }
}
