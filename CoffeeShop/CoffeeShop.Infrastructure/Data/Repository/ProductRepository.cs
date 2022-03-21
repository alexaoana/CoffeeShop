using CoffeeShop.Core;
using CoffeeShop.Core.Abstract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Infrastructure.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private AppDBContext _appDBContext;
        public ProductRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public Product GetProduct(int id)
        {
           return _appDBContext.Products.SingleOrDefault(o => o.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _appDBContext.Products;
        }

        public void AddProduct(Product product)
        {
            _appDBContext.Products.Add(product);
        }

        public void RemoveProduct(int id)
        {
            _appDBContext.Products.Remove(GetProduct(id));
        }

        public void UpdateProduct(Product product)
        {
            foreach (var item in _appDBContext.Products)
                if (item.Id == product.Id)
                {
                    item.ProductOrders = product.ProductOrders;
                    item.ProductUnitEnum = product.ProductUnitEnum;
                    item.AvailableQuantity = product.AvailableQuantity;
                    item.Amount = product.Amount;
                    item.Image = product.Image;
                    item.Description = product.Description;
                    item.Name = product.Name;
                }
        }
    }
}
