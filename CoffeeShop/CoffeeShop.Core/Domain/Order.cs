using CoffeeShop.Core.Enums;

namespace CoffeeShop.Core
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal Price
        {
            get
            {
                return ProductOrders
                    .Aggregate(decimal.Zero, (price, productOrder) => price + productOrder.Quantity * productOrder.Product.Price);
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
