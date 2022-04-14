using CoffeeShop.Core.Enums;

namespace CoffeeShop.Core.DTOs
{
    public class OrderDTO
    {
        public User User { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<ProductOrder>? ProductOrders { get; set; }
        public double Price { get; }
        public int NumberOfProducts { get; }
    }
}
