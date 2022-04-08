using CoffeeShop.Core.Enums;

namespace CoffeeShop.Core.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public User User { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<ProductOrder>? ProductOrders { get; set; }
        public decimal Price { get; }
        public int NumberOfProducts { get; }
    }
}
