using CoffeeShop.Core;

namespace CoffeeShop.Infrastructure.Data
{
    public class AppDBContext
    {
        public IList<User> Users = new List<User>();
        public IList<Product> Products = new List<Product>();
        public IList<Order> Orders = new List<Order>();
        public IList<ProductOrder> ProductOrders = new List<ProductOrder>();
    }
}
