using CoffeeShop.Core.Enums;
using System.Text.Json.Serialization;

namespace CoffeeShop.Core.DTOs
{
    public class OrderDTO
    {
        [JsonIgnore]
        public User User { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<ProductOrder>? ProductOrders { get; set; }
        public double Price { get; set; }
        public int NumberOfProducts { get; set; }
    }
}
