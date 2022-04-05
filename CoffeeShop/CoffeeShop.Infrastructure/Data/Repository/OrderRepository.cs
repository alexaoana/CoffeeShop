using CoffeeShop.Core;
using CoffeeShop.Core.Abstract.Repository;
using CoffeeShop.Core.Paginate;

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

        public IEnumerable<Order> GetOrders(Filter filter)
        {
            return _appDBContext.Orders
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);
        }

        public void AddOrder(Order order)
        {
            _appDBContext.Orders.Add(order);
            _appDBContext.SaveChanges();
        }

        public void RemoveOrder(int id)
        {
            _appDBContext.Orders.Remove(GetOrder(id));
            _appDBContext.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            foreach (var item in _appDBContext.Orders)
                if (item.Id == order.Id)
                {
                    item.OrderStatus = order.OrderStatus;
                }
            _appDBContext.SaveChanges();
        }
    }
}
