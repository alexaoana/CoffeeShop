using CoffeeShop.Core.Enums;

namespace CoffeeShop.Core
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
    }
}
