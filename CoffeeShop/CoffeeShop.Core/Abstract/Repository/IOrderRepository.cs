using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Abstract.Repository
{
    public interface IOrderRepository
    {
        Order GetOrder(int id);
        IEnumerable<Order> GetOrders();
        void AddOrder(Order order);
        void RemoveOrder(int id);
        void UpdateOrder(Order order);
    }
}
