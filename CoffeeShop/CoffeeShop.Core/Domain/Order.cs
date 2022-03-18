using CoffeeShop.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
    }
}
