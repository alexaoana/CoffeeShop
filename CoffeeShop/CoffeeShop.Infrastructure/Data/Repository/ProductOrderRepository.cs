using CoffeeShop.Core;
using CoffeeShop.Core.Abstract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AddProductOrder(ProductOrder productOrder)
        {
            _appDBContext.ProductOrders.Add(productOrder);
        }

        public void RemoveProductOrder(int id)
        {
            _appDBContext.ProductOrders.Remove(GetProductOrder(id));
        }

        public void UpdateProductOrder(ProductOrder productOrder)
        {
            var item = GetProductOrder(productOrder.Id);
            item = productOrder;
        }
    }
}
