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
           foreach (Product product in _appDBContext.Products)
                if (product.Id == id)
                    return product;
           return null;
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
            RemoveProduct(product.Id);
            AddProduct(product);
        }
    }
}
