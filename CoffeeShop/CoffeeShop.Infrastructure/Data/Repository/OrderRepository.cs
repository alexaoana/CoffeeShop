using CoffeeShop.Core;
using CoffeeShop.Core.Abstract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Infrastructure.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private AppDBContext _appDBContext;

        public OrderRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public Order GetOrder(int id)
        {
            return _appDBContext.Orders.SingleOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _appDBContext.Orders;
        }

        public void AddOrder(Order order)
        {
            _appDBContext.Orders.Add(order);
        }

        public void RemoveOrder(int id)
        {
            _appDBContext.Orders.Remove(GetOrder(id));
        }

        public void UpdateOrder(Order order)
        {
            var item = GetOrder(order.Id);
            item = order;
        }
    }
}
