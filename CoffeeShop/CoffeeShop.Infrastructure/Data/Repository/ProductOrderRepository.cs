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
            foreach (var productOrder in _appDBContext.ProductOrders)
                if (productOrder.Id == id)
                    return productOrder;
            return null;
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
            RemoveProductOrder(productOrder.Id);
            AddProductOrder(productOrder);
        }
    }
}
