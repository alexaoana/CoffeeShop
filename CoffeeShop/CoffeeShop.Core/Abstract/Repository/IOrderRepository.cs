using CoffeeShop.Core.Paginate;

namespace CoffeeShop.Core.Abstract.Repository
{
    public interface IOrderRepository
    {
        Order GetOrder(int id);
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrders(Filter filter);
        void AddOrder(Order order);
        void RemoveOrder(int id);
        void UpdateOrder(Order order);
    }
}
