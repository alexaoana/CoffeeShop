using CoffeeShop.Core;
using CoffeeShop.Core.Abstract.Repository;
using CoffeeShop.Core.Paginate;

namespace CoffeeShop.Infrastructure.Data.Repository
{
    public class ProductOrderRepository : IProductOrderRepository
    {
        private AppDBContext _appDBContext;

        public ProductOrderRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public ProductOrder GetProductOrder(int id)
        {
            return _appDBContext.ProductOrders.SingleOrDefault(o => o.Id == id);
        }

        public IEnumerable<ProductOrder> GetProductOrders()
        {
            return _appDBContext.ProductOrders;
        }

        public IEnumerable<ProductOrder> GetProductOrders(Filter filter)
        {
            return _appDBContext.ProductOrders
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);
        }

        public void AddProductOrder(ProductOrder productOrder)
        {
            _appDBContext.ProductOrders.Add(productOrder);
            _appDBContext.SaveChanges();
        }

        public void RemoveProductOrder(int id)
        {
            _appDBContext.ProductOrders.Remove(GetProductOrder(id));
            _appDBContext.SaveChanges();
        }

        public void UpdateProductOrder(ProductOrder productOrder)
        {
            var item = GetProductOrder(productOrder.Id);
            item = productOrder;
            _appDBContext.SaveChanges();
        }
    }
}
