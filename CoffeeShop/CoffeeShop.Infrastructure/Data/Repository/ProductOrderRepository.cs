using CoffeeShop.Core;
using CoffeeShop.Core.Abstract.Repository;
using CoffeeShop.Core.Paginate;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Infrastructure.Data.Repository
{
    public class ProductOrderRepository : IProductOrderRepository
    {
        private AppDbContext _appDbContext;

        public ProductOrderRepository(AppDbContext appDBContext)
        {
            _appDbContext = appDBContext;
        }

        public ProductOrder GetProductOrder(int id)
        {
            return _appDbContext.ProductOrders
                .Include(x => x.Product)
                .SingleOrDefault(o => o.Id == id);
        }

        public IEnumerable<ProductOrder> GetProductOrders()
        {
            return _appDbContext.ProductOrders
                .Include(x => x.Product);
        }

        public IEnumerable<ProductOrder> GetProductOrders(Filter filter)
        {
            return _appDbContext.ProductOrders
                .Include(x => x.Product)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);
        }

        public void AddProductOrder(ProductOrder productOrder)
        {
            _appDbContext.ProductOrders.Add(productOrder);
            _appDbContext.SaveChanges();
        }

        public void RemoveProductOrder(int id)
        {
            _appDbContext.ProductOrders.Remove(GetProductOrder(id));
            _appDbContext.SaveChanges();
        }

        public void UpdateProductOrder(ProductOrder productOrder)
        {
            var item = GetProductOrder(productOrder.Id);
            item = productOrder;
            _appDbContext.SaveChanges();
        }
    }
}
