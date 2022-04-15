using CoffeeShop.Core;
using CoffeeShop.Core.Abstract.Repository;
using CoffeeShop.Core.Paginate;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Infrastructure.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDBContext)
        {
            _appDbContext = appDBContext;
        }

        public Order GetOrder(int id)
        {
            return _appDbContext.Orders
                .Include(x => x.ProductOrders)
                .Include(x => x.User)
                .SingleOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _appDbContext.Orders
                .Include(x => x.ProductOrders)
                .Include(x => x.User);
        }

        public IEnumerable<Order> GetOrders(Filter filter)
        {
            return _appDbContext.Orders
                .Include(x => x.ProductOrders)
                .Include(x => x.User)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);
        }

        public void AddOrder(Order order)
        {
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();
        }

        public void RemoveOrder(int id)
        {
            _appDbContext.Orders.Remove(GetOrder(id));
            _appDbContext.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            foreach (var item in _appDbContext.Orders)
                if (item.Id == order.Id)
                    item.OrderStatus = order.OrderStatus;
            _appDbContext.SaveChanges();
        }
    }
}
