using CoffeeShop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
